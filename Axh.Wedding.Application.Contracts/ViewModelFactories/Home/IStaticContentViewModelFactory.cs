namespace Axh.Wedding.Application.Contracts.ViewModelFactories.Home
{
    using Axh.Wedding.Application.ViewModels.Home;

    public interface IStaticContentViewModelFactory
    {
        HomePageViewModel GetHomePageViewModel(string user, bool isAdmin);

        InformationPageViewModel GetInformationPageViewModel(string user, bool isAdmin);

        ContactPageViewModel GetContactPageViewModel(string user, bool isAdmin);
    }
}