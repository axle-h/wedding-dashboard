namespace Axh.Wedding.Application.Contracts.ViewModelFactories.Account
{
    using Axh.Core.DomainModels.Accounts;
    using Axh.Wedding.Application.Contracts.Models.Account;
    using Axh.Wedding.Application.ViewModels.Account;

    public interface IAccountViewModelFactory
    {
        LoginPageViewModel GetLoginViewModel(string returnUrl);

        LoginPageViewModel GetLoginViewModel(LoginPageViewModel loginPageViewModel);
        UserViewModel GetUserViewModel(WeddingUser weddingUser);

        UserViewModel GetUserViewModel(User user);
    }
}