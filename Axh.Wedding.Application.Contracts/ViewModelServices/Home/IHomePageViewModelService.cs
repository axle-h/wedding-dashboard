namespace Axh.Wedding.Application.Contracts.ViewModelServices.Home
{
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Home;

    public interface IHomePageViewModelService
    {
        HomePageViewModel GetHomePageViewModel(UserViewModel user);

        InformationPageViewModel GetInformationPageViewModel(UserViewModel user);

        ContactPageViewModel GetContactPageViewModel(UserViewModel user);
    }
}