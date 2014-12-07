namespace Axh.Wedding.Application.Contracts.ViewModelServices.Home
{
    using Axh.Wedding.Application.ViewModels.Home;

    public interface IHomePageViewModelService
    {
        HomePageViewModel GetHomePageViewModel(string user, bool isAdmin);

        InformationPageViewModel GetInformationPageViewModel(string user, bool isAdmin);

        ContactPageViewModel GetContactPageViewModel(string user, bool isAdmin);
    }
}