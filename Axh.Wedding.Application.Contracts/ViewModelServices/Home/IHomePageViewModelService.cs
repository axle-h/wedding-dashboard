namespace Axh.Wedding.Application.Contracts.ViewModelServices.Home
{
    using Axh.Wedding.Application.ViewModels.Home;

    public interface IHomePageViewModelService
    {
        HomePageViewModel GetHomePageViewModel();

        InformationPageViewModel GetInformationPageViewModel();

        ContactPageViewModel GetContactPageViewModel();
    }
}