namespace Axh.Wedding.Application.Contracts.ViewModelFactories.Admin
{
    using System.Collections.Generic;

    using Axh.Core.DomainModels.Wedding;
    using Axh.Wedding.Application.Contracts.Models.Account;
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Admin;
    using Axh.Wedding.Application.ViewModels.Page;

    public interface IAdminViewModelFactory
    {
        AdminPageViewModel GetAdminPageViewModel(UserViewModel user, IEnumerable<WeddingUser> users, IList<Rsvp> rsvps);

        EditUserPageViewModel GetEditUserPageViewModel(UserViewModel user, WeddingUser weddingUser);

        AdminRsvpPageViewModel GetAdminRsvpPageViewModel(UserViewModel user, Rsvp rsvp);
    }
}