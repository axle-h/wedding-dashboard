namespace Axh.Wedding.Application.ViewModelService.Account
{
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Account;
    using Axh.Wedding.Application.Contracts.ViewModelServices.Account;
    using Axh.Wedding.Application.ViewModels.Account;

    public class AccountViewModelService : IAccountViewModelService
    {
        private readonly IAccountViewModelFactory accountViewModelFactory;

        public AccountViewModelService(IAccountViewModelFactory accountViewModelFactory)
        {
            this.accountViewModelFactory = accountViewModelFactory;
        }

        public LoginPageViewModel GetLoginViewModel(string returnUrl)
        {
            return this.accountViewModelFactory.GetLoginViewModel(returnUrl);
        }

        public LoginPageViewModel GetLoginViewModel(LoginPageViewModel loginPageViewModel)
        {
            return this.accountViewModelFactory.GetLoginViewModel(loginPageViewModel);
        }
    }
}
