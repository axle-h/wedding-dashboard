namespace Axh.Wedding.Application.Contracts.ViewModelFactories.Account
{
    using Axh.Wedding.Application.ViewModels.Account;

    public interface IAccountViewModelFactory
    {
        LoginPageViewModel GetLoginViewModel(string returnUrl);

        UserViewModel GetUserViewModel(string userName);

        LoginPageViewModel GetLoginViewModel(LoginPageViewModel loginPageViewModel);
    }
}