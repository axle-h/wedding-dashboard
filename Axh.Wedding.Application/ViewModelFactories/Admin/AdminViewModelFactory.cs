namespace Axh.Wedding.Application.ViewModelFactories.Admin
{
    using Axh.Wedding.Application.Contracts.Helpers;
    using Axh.Wedding.Application.Contracts.ViewModelFactories;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Account;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Admin;
    using Axh.Wedding.Application.ViewModels.Admin;
    using Axh.Wedding.Resources;

    public class AdminViewModelFactory : IAdminViewModelFactory
    {
        private readonly IPageViewModelFactory pageViewModelFactory;

        private readonly IAccountViewModelFactory accountViewModelFactory;

        private readonly IWeddingUrlHelper weddingUrlHelper;

        public AdminViewModelFactory(IPageViewModelFactory pageViewModelFactory, IAccountViewModelFactory accountViewModelFactory, IWeddingUrlHelper weddingUrlHelper)
        {
            this.pageViewModelFactory = pageViewModelFactory;
            this.accountViewModelFactory = accountViewModelFactory;
            this.weddingUrlHelper = weddingUrlHelper;
        }

        public AdminPageViewModel GetAdminPageViewModel(string user)
        {
            var model = new AdminPageViewModel();

            return PrepareAdminPageViewModel(user, model);
        }

        public AdminPageViewModel PrepareAdminPageViewModel(string user, AdminPageViewModel viewModel)
        {
            var model = this.pageViewModelFactory.PreparePageViewModel(viewModel,
                accountViewModelFactory.GetUserViewModel(user, true),
                weddingUrlHelper.HomePageHeader,
                Resources.AdminPage_Link,
                Resources.AdminPage_Title);

            return model;
        }
    }
}
