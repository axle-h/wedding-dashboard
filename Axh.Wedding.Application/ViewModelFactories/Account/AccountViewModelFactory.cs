namespace Axh.Wedding.Application.ViewModelFactories.Account
{
    using Axh.Wedding.Application.Contracts.Helpers;
    using Axh.Wedding.Application.Contracts.ViewModelFactories;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Account;
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Resources;

    public class AccountViewModelFactory : IAccountViewModelFactory
    {
        private readonly IPageViewModelFactory pageViewModelFactory;

        private readonly IWeddingUrlHelper weddingUrlHelper;

        public AccountViewModelFactory(IPageViewModelFactory pageViewModelFactory, IWeddingUrlHelper weddingUrlHelper)
        {
            this.pageViewModelFactory = pageViewModelFactory;
            this.weddingUrlHelper = weddingUrlHelper;
        }

        public LoginPageViewModel GetLoginViewModel(string returnUrl)
        {
            var model = new LoginPageViewModel {ReturnUrl = returnUrl};
            return PrepareLoginPageViewModel(model);
        }

        public LoginPageViewModel GetLoginViewModel(LoginPageViewModel loginPageViewModel)
        {
            return PrepareLoginPageViewModel(loginPageViewModel);
        }

        private LoginPageViewModel PrepareLoginPageViewModel(LoginPageViewModel model)
        {
            return this.pageViewModelFactory.PreparePageViewModel(
                model,
                null,
                weddingUrlHelper.LoginPageHeader,
                Resources.LoginPage_Link,
                Resources.LoginPage_Title,
                Resources.LoginPage_SubTitle);
        }
    }
}
