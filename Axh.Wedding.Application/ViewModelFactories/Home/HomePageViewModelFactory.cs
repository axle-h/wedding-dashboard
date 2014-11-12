namespace Axh.Wedding.Application.ViewModelFactories.Home
{
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Home;
    using Axh.Wedding.Application.ViewModels.Home;
    using Axh.Wedding.Resources;

    public class HomePageViewModelFactory : IHomePageViewModelFactory
    {
        public HomePageViewModel GetHomePageViewModel()
        {
            return new HomePageViewModel(Resources.HomePage_Title);
        }
    }
}
