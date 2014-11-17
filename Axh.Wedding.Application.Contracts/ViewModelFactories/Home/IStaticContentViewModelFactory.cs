namespace Axh.Wedding.Application.Contracts.ViewModelFactories.Home
{
    using Axh.Wedding.Application.ViewModels.Home;

    public interface IStaticContentViewModelFactory
    {
        HomePageViewModel GetHomePageViewModel();

        InformationPageViewModel GetInformationPageViewModel();

        ContactPageViewModel GetContactPageViewModel();
    }
}