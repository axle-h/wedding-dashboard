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
            var model = new AdminPageViewModel();

            model.Users = users.Select(this.accountViewModelFactory.GetUserViewModel);

            return PrepareAdminPageViewModel(user, model);
        }

        public AdminPageViewModel PrepareAdminPageViewModel(UserViewModel user, AdminPageViewModel viewModel)
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
