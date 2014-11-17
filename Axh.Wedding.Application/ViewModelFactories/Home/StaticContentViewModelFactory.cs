namespace Axh.Wedding.Application.ViewModelFactories.Home
{
    using Axh.Wedding.Application.Contracts;
    using Axh.Wedding.Application.Contracts.ViewModelFactories;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Home;
    using Axh.Wedding.Application.ViewModels.Home;
    using Axh.Wedding.Resources;

    public class StaticContentViewModelFactory : IStaticContentViewModelFactory
    {
        private readonly IPageViewModelFactory pageViewModelFactory;

        public StaticContentViewModelFactory(IPageViewModelFactory pageViewModelFactory)
        {
            this.pageViewModelFactory = pageViewModelFactory;
        }

        public HomePageViewModel GetHomePageViewModel()
        {
            return this.pageViewModelFactory.GetPageViewModel<HomePageViewModel>(Resources.HomePage_Title);
        }

        public InformationPageViewModel GetInformationPageViewModel()
        {
            return this.pageViewModelFactory.GetPageViewModel<InformationPageViewModel>(Resources.InformationPage_Title);
        }

        public ContactPageViewModel GetContactPageViewModel()
        {
            return this.pageViewModelFactory.GetPageViewModel<ContactPageViewModel>(Resources.ContactPage_Title);
        }
    }
}
