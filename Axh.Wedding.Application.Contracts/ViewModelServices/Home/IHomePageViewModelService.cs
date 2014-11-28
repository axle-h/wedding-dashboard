namespace Axh.Wedding.Application.Contracts.ViewModelServices.Home
{
    using Axh.Wedding.Application.ViewModels.Home;

    public interface IHomePageViewModelService
    {
        HomePageViewModel GetHomePageViewModel(string user);

        InformationPageViewModel GetInformationPageViewModel(string user);

        ContactPageViewModel GetContactPageViewModel(string user);
    }
}