namespace Axh.Wedding.Application.Contracts.ViewModelFactories.Home
{
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Home;

    public interface IStaticContentViewModelFactory
    {
        HomePageViewModel GetHomePageViewModel(UserViewModel user);

        InformationPageViewModel GetInformationPageViewModel(UserViewModel user);

        ContactPageViewModel GetContactPageViewModel(UserViewModel user);
    }
}