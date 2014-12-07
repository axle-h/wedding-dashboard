namespace Axh.Wedding.Application.ViewModelService.Home
{
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Home;
    using Axh.Wedding.Application.Contracts.ViewModelServices.Home;
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Home;

    public class HomePageViewModelService : IHomePageViewModelService
    {
        private readonly IStaticContentViewModelFactory staticContentViewModelFactory;

        public HomePageViewModelService(IStaticContentViewModelFactory staticContentViewModelFactory)
        {
            this.staticContentViewModelFactory = staticContentViewModelFactory;
        }

        public HomePageViewModel GetHomePageViewModel(UserViewModel user)
        {
            return this.staticContentViewModelFactory.GetHomePageViewModel(user);
        }

        public InformationPageViewModel GetInformationPageViewModel(UserViewModel user)
        {
            return this.staticContentViewModelFactory.GetInformationPageViewModel(user);
        }

        public ContactPageViewModel GetContactPageViewModel(UserViewModel user)
        {
            return this.staticContentViewModelFactory.GetContactPageViewModel(user);
        }
    }
}
