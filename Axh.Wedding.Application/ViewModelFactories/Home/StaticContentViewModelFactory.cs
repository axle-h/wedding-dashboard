namespace Axh.Wedding.Application.ViewModelFactories.Home
{
    using Axh.Wedding.Application.Contracts.Helpers;
    using Axh.Wedding.Application.Contracts.ViewModelFactories;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Home;
    using Axh.Wedding.Application.ViewModels.Home;
    using Axh.Wedding.Resources;

    public class StaticContentViewModelFactory : IStaticContentViewModelFactory
    {
        private readonly IPageViewModelFactory pageViewModelFactory;

        private readonly IWeddingUrlHelper weddingUrlHelper;

        public StaticContentViewModelFactory(IPageViewModelFactory pageViewModelFactory, IWeddingUrlHelper weddingUrlHelper)
        {
            this.pageViewModelFactory = pageViewModelFactory;
            this.weddingUrlHelper = weddingUrlHelper;
        }

        public HomePageViewModel GetHomePageViewModel()
        {
            return this.pageViewModelFactory.GetPageViewModel<HomePageViewModel>(weddingUrlHelper.HomePageHeader, false, Resources.HomePage_Title);
        }

        public InformationPageViewModel GetInformationPageViewModel()
        {
            return this.pageViewModelFactory.GetPageViewModel<InformationPageViewModel>(weddingUrlHelper.InfoPageHeader, true, Resources.InformationPage_Title, Resources.InformationPage_SubTitle);
        }

        public ContactPageViewModel GetContactPageViewModel()
        {
            return this.pageViewModelFactory.GetPageViewModel<ContactPageViewModel>(weddingUrlHelper.ContactPageHeader, true, Resources.ContactPage_Title, Resources.ContactPage_SubTitle);
        }
    }
}
