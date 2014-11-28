namespace Axh.Wedding.Application.Contracts.ViewModelFactories.Home
{
    using Axh.Wedding.Application.ViewModels.Home;

    public interface IStaticContentViewModelFactory
    {
        HomePageViewModel GetHomePageViewModel(string user);

        InformationPageViewModel GetInformationPageViewModel(string user);

        ContactPageViewModel GetContactPageViewModel(string user);
    }
}