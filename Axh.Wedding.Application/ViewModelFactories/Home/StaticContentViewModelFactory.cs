namespace Axh.Wedding.Application.ViewModelFactories.Home
{
    using System.Linq;
    using Axh.Wedding.Application.Contracts.Config;
    using Axh.Wedding.Application.Contracts.Helpers;
    using Axh.Wedding.Application.Contracts.ViewModelFactories;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Account;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Home;
    using Axh.Wedding.Application.ViewModels.Home;
    using Axh.Wedding.Application.ViewModels.Page;
    using Axh.Wedding.Resources;

    public class StaticContentViewModelFactory : IStaticContentViewModelFactory
    {
        private readonly IPageViewModelFactory pageViewModelFactory;

        private readonly IWeddingUrlHelper weddingUrlHelper;

        private readonly IWeddingConfig weddingConfig;

        private readonly IAccountViewModelFactory accountViewModelFactory;

        public StaticContentViewModelFactory(IPageViewModelFactory pageViewModelFactory, IWeddingUrlHelper weddingUrlHelper, IWeddingConfig weddingConfig, IAccountViewModelFactory accountViewModelFactory)
        {
            this.pageViewModelFactory = pageViewModelFactory;
            this.weddingUrlHelper = weddingUrlHelper;
            this.weddingConfig = weddingConfig;
            this.accountViewModelFactory = accountViewModelFactory;
        }

        public HomePageViewModel GetHomePageViewModel(string user, bool isAdmin)
        {
            return this.pageViewModelFactory.GetPageViewModel<HomePageViewModel>(
                accountViewModelFactory.GetUserViewModel(user, isAdmin),
                weddingUrlHelper.HomePageHeader,
                Resources.HomePage_Link,
                Resources.HomePage_Title,
                null,
                weddingUrlHelper.Rsvp,
                Resources.RsvpPage_Link);
        }

        public InformationPageViewModel GetInformationPageViewModel(string user, bool isAdmin)
        {
            var viewModel = this.pageViewModelFactory.GetPageViewModel<InformationPageViewModel>(
                accountViewModelFactory.GetUserViewModel(user, isAdmin),
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

        public ContactPageViewModel GetContactPageViewModel(string user, bool isAdmin)
        {
            var model = this.pageViewModelFactory.GetPageViewModel<ContactPageViewModel>(
                accountViewModelFactory.GetUserViewModel(user, isAdmin),
                weddingUrlHelper.ContactPageHeader,
                Resources.ContactPage_Link,
                Resources.ContactPage_Title,
                Resources.ContactPage_SubTitle);

            model.GroomSocialCircles = model.Footer.SocialCircles;
            model.Footer.SocialCircles = Enumerable.Empty<SocialCircleViewModel>();

            model.BrideSocialCircles = new[]
            {
                new SocialCircleViewModel(this.weddingConfig.BrideFacebook, SocialCircleType.Facebook),
                new SocialCircleViewModel(this.weddingConfig.BrideEmail, SocialCircleType.Email)
            };

            return model;
        }
    }
}
