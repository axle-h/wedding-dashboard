namespace Axh.Wedding.Application.ViewModelFactories.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Axh.Core.Common;
    using Axh.Core.DomainModels.Wedding;
    using Axh.Wedding.Application.Contracts.Helpers;
    using Axh.Wedding.Application.Contracts.Models.Account;
    using Axh.Wedding.Application.Contracts.ViewModelFactories;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Account;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Admin;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Rsvp;
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Admin;
    using Axh.Wedding.Application.ViewModels.Page;
    using Axh.Wedding.Resources;

    public class AdminViewModelFactory : IAdminViewModelFactory
    {
        private readonly IPageViewModelFactory pageViewModelFactory;

        private readonly IWeddingUrlHelper weddingUrlHelper;

        private readonly IAccountViewModelFactory accountViewModelFactory;

        private readonly IRsvpViewModelFactory rsvpViewModelFactory;

        public AdminViewModelFactory(IPageViewModelFactory pageViewModelFactory, IWeddingUrlHelper weddingUrlHelper, IAccountViewModelFactory accountViewModelFactory, IRsvpViewModelFactory rsvpViewModelFactory)
        {
            this.pageViewModelFactory = pageViewModelFactory;
            this.weddingUrlHelper = weddingUrlHelper;
            this.accountViewModelFactory = accountViewModelFactory;
            this.rsvpViewModelFactory = rsvpViewModelFactory;
        }

        public AdminPageViewModel GetAdminPageViewModel(UserViewModel user, IEnumerable<WeddingUser> users, IList<Rsvp> rsvps)
        {
            var userViewModels = users.Select(x => new { ViewModel = this.accountViewModelFactory.GetUserViewModel(x), User = x }).ToArray();
            var merged = userViewModels.GroupJoin(rsvps, u => u.ViewModel.UserId, r => r.Id, (u, r) => new { u.User, u.ViewModel, Rsvp = r.FirstOrDefault() }).ToArray();

            var invited = merged.SelectMany(x => x.User.Guests.Select(y => new { x.ViewModel.RsvpType, Guest = y })).GroupBy(x => x.RsvpType).ToDictionary(grp => grp.Key, grp => grp.Count());
            var rsvpGuestsByType = merged.Where(x => x.Rsvp != null).SelectMany(x => x.Rsvp.Guests.Select(y => new { x.ViewModel.RsvpType, Guest = y })).GroupBy(x => x.RsvpType).ToArray();

            var model = new AdminPageViewModel
                        {
                            Users = userViewModels.Select(x => x.ViewModel),
                            Invited = invited,
                            Attending = rsvpGuestsByType.ToDictionary(x => x.Key, x => x.Count(y => y.Guest.IsAttending)),
                            NotAttending = rsvpGuestsByType.ToDictionary(x => x.Key, x => x.Count(y => !y.Guest.IsAttending))
                        };

            model.Responded = model.Invited.Keys.ToDictionary(x => x, x => (model.Attending.ContainsKey(x) ? model.Attending[x] : 0) + (model.NotAttending.ContainsKey(x) ? model.NotAttending[x] : 0));

            return PrepareAdminPageViewModel(user, model);
        }

        public EditUserPageViewModel GetEditUserPageViewModel(UserViewModel user, WeddingUser weddingUser)
        {
            var editUser = this.accountViewModelFactory.GetUserViewModel(weddingUser);
            var model = new EditUserPageViewModel { UserId = editUser.UserId, UserName = editUser.UserName, IsAdmin = editUser.IsAdmin, RsvpType = editUser.RsvpType };

            return PrepareAdminPageViewModel(user, model);
        }

        public AdminRsvpPageViewModel GetAdminRsvpPageViewModel(UserViewModel user, Rsvp rsvp)
        {
            var rsvpUser = this.accountViewModelFactory.GetUserViewModel(rsvp.User);
            var rsvpViewModel = rsvpViewModelFactory.GetRsvpPageViewModel(rsvpUser, rsvp);

            var model = new AdminRsvpPageViewModel
                        {
                            RsvpUser = rsvpUser,
                            Guests = rsvpViewModel.Guests,
                            Stories = rsvpViewModel.Stories,
                            WeddingPartyMemberLabels = rsvpViewModel.WeddingPartyMemberLabels,
                            RsvpResponseLabels = rsvpViewModel.RsvpResponseLabels
                        };
            return PrepareAdminPageViewModel(user, model);
        }

        private TPageViewModel PrepareAdminPageViewModel<TPageViewModel>(UserViewModel user, TPageViewModel viewModel)
            where TPageViewModel : PageViewModelBase, new()
        {
            var model = this.pageViewModelFactory.PreparePageViewModel(viewModel,
                user,
                weddingUrlHelper.HomePageHeader,
                Resources.AdminPage_Link,
                Resources.AdminPage_Title);

            return model;
        }
    }
}
