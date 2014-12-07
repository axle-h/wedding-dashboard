namespace Axh.Wedding.Application.ViewModelService.Home
{
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Home;
    using Axh.Wedding.Application.Contracts.ViewModelServices.Home;
    using Axh.Wedding.Application.ViewModels.Home;

    public class HomePageViewModelService : IHomePageViewModelService
    {
        private readonly IStaticContentViewModelFactory staticContentViewModelFactory;

        public HomePageViewModelService(IStaticContentViewModelFactory staticContentViewModelFactory)
        {
            this.staticContentViewModelFactory = staticContentViewModelFactory;
        }

        public HomePageViewModel GetHomePageViewModel(string user, bool isAdmin)
        {
            return this.staticContentViewModelFactory.GetHomePageViewModel(user, isAdmin);
        }

        public InformationPageViewModel GetInformationPageViewModel(string user, bool isAdmin)
        {
            return this.staticContentViewModelFactory.GetInformationPageViewModel(user, isAdmin);
        }

        public ContactPageViewModel GetContactPageViewModel(string user, bool isAdmin)
        {
            return this.staticContentViewModelFactory.GetContactPageViewModel(user, isAdmin);
        }
    }
}
