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
            var model = this.pageViewModelFactory.GetPageViewModel<LoginPageViewModel>(
                null,
                weddingUrlHelper.LoginPageHeader,
                Resources.LoginPage_Link,
                Resources.LoginPage_Title,
                Resources.LoginPage_SubTitle);

            model.ReturnUrl = returnUrl;
            return model;
        }

        public UserViewModel GetUserViewModel(string userName)
        {
            return new UserViewModel { UserName = userName };
        }
    }
}
