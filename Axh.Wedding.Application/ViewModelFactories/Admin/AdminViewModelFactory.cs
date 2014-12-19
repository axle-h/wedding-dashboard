namespace Axh.Wedding.Application.ViewModelFactories.Admin
{
    using System.Collections.Generic;
    using System.Linq;
    using Axh.Wedding.Application.Contracts.Helpers;
    using Axh.Wedding.Application.Contracts.Models.Account;
    using Axh.Wedding.Application.Contracts.ViewModelFactories;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Account;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Admin;
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Admin;
    using Axh.Wedding.Application.ViewModels.Page;
    using Axh.Wedding.Resources;

    public class AdminViewModelFactory : IAdminViewModelFactory
    {
        private readonly IPageViewModelFactory pageViewModelFactory;

        private readonly IWeddingUrlHelper weddingUrlHelper;

        private readonly IAccountViewModelFactory accountViewModelFactory;

        public AdminViewModelFactory(IPageViewModelFactory pageViewModelFactory, IWeddingUrlHelper weddingUrlHelper, IAccountViewModelFactory accountViewModelFactory)
        {
            this.pageViewModelFactory = pageViewModelFactory;
            this.weddingUrlHelper = weddingUrlHelper;
            this.accountViewModelFactory = accountViewModelFactory;
        }

        public AdminPageViewModel GetAdminPageViewModel(UserViewModel user, IEnumerable<WeddingUser> users)
        {
            var model = new AdminPageViewModel { Users = users.Select(this.accountViewModelFactory.GetUserViewModel) };

            return PrepareAdminPageViewModel(user, model);
        }

        public EditUserPageViewModel GetEditUserPageViewModel(UserViewModel user, WeddingUser weddingUser)
        {
            var editUser = this.accountViewModelFactory.GetUserViewModel(weddingUser);
            var model = new EditUserPageViewModel { UserId = editUser.UserId, UserName = editUser.UserName, IsAdmin = editUser.IsAdmin };

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
