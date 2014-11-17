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

        public HomePageViewModel GetHomePageViewModel()
        {
            return this.staticContentViewModelFactory.GetHomePageViewModel();
        }

        public InformationPageViewModel GetInformationPageViewModel()
        {
            return this.staticContentViewModelFactory.GetInformationPageViewModel();
        }

        public ContactPageViewModel GetContactPageViewModel()
        {
            return this.staticContentViewModelFactory.GetContactPageViewModel();
        }
    }
}
