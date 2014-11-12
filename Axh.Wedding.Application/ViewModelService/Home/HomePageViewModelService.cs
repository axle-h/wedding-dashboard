namespace Axh.Wedding.Application.ViewModelService.Home
{
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Home;
    using Axh.Wedding.Application.Contracts.ViewModelServices.Home;
    using Axh.Wedding.Application.ViewModels.Home;

    public class HomePageViewModelService : IHomePageViewModelService
    {
        private readonly IHomePageViewModelFactory homePageViewModelFactory;

        public HomePageViewModelService(IHomePageViewModelFactory homePageViewModelFactory)
        {
            this.homePageViewModelFactory = homePageViewModelFactory;
        }

        public HomePageViewModel GetHomePageViewModel()
        {
            return this.homePageViewModelFactory.GetHomePageViewModel();
        }
    }
}
