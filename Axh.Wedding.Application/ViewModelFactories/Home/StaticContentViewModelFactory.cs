namespace Axh.Wedding.Application.ViewModelFactories.Home
{
    using Axh.Wedding.Application.Contracts.Config;
    using Axh.Wedding.Application.Contracts.Helpers;
    using Axh.Wedding.Application.Contracts.ViewModelFactories;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Home;
    using Axh.Wedding.Application.ViewModels.Home;
    using Axh.Wedding.Resources;

    public class StaticContentViewModelFactory : IStaticContentViewModelFactory
    {
        private readonly IPageViewModelFactory pageViewModelFactory;

        private readonly IWeddingUrlHelper weddingUrlHelper;

        private readonly IWeddingConfig weddingConfig;

        public StaticContentViewModelFactory(IPageViewModelFactory pageViewModelFactory, IWeddingUrlHelper weddingUrlHelper, IWeddingConfig weddingConfig)
        {
            this.pageViewModelFactory = pageViewModelFactory;
            this.weddingUrlHelper = weddingUrlHelper;
            this.weddingConfig = weddingConfig;
        }

        public HomePageViewModel GetHomePageViewModel()
        {
            return this.pageViewModelFactory.GetPageViewModel<HomePageViewModel>(
                weddingUrlHelper.HomePageHeader,
                Resources.HomePage_Link,
                Resources.HomePage_Title,
                null,
                weddingUrlHelper.Rsvp,
                Resources.RsvpPage_Link);
        }

        public InformationPageViewModel GetInformationPageViewModel()
        {
            var viewModel = this.pageViewModelFactory.GetPageViewModel<InformationPageViewModel>(
                weddingUrlHelper.InfoPageHeader,
                Resources.InformationPage_Link,
                Resources.InformationPage_Title,
                Resources.InformationPage_SubTitle);

            viewModel.VenueAddress = weddingConfig.VenueAddress;
            viewModel.VenuePhone = weddingConfig.VenuePhone;

            viewModel.HotelAddress = weddingConfig.HotelAddress;
            viewModel.HotelPhone = weddingConfig.HotelPhone;

            return viewModel;
        }

        public ContactPageViewModel GetContactPageViewModel()
        {
            return this.pageViewModelFactory.GetPageViewModel<ContactPageViewModel>(
                weddingUrlHelper.ContactPageHeader,
                Resources.ContactPage_Link,
                Resources.ContactPage_Title,
                Resources.ContactPage_SubTitle);
        }
    }
}
