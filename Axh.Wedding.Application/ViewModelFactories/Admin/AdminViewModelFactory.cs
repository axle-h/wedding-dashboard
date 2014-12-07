namespace Axh.Wedding.Application.ViewModelFactories.Admin
{
    using Axh.Wedding.Application.Contracts.Helpers;
    using Axh.Wedding.Application.Contracts.ViewModelFactories;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Admin;
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Admin;
    using Axh.Wedding.Resources;

    public class AdminViewModelFactory : IAdminViewModelFactory
    {
        private readonly IPageViewModelFactory pageViewModelFactory;

        private readonly IWeddingUrlHelper weddingUrlHelper;

        public AdminViewModelFactory(IPageViewModelFactory pageViewModelFactory, IWeddingUrlHelper weddingUrlHelper)
        {
            this.pageViewModelFactory = pageViewModelFactory;
            this.weddingUrlHelper = weddingUrlHelper;
        }

        public AdminPageViewModel GetAdminPageViewModel(UserViewModel user)
        {
            var model = new AdminPageViewModel();

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
