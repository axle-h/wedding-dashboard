namespace Axh.Wedding.Application.Contracts.ViewModelServices.Account
{
    using Axh.Wedding.Application.ViewModels.Account;

    public interface IAccountViewModelService
    {
        LoginPageViewModel GetLoginViewModel(string returnUrl);
        LoginPageViewModel GetLoginViewModel(LoginPageViewModel loginPageViewModel);
    }
}