namespace Axh.Wedding.Application.ViewModelFactories
{
    using Axh.Wedding.Application.Contracts.Config;
    using Axh.Wedding.Application.Contracts.ViewModelFactories;
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Page;

    using Axh.Wedding.Resources;

    public class PageViewModelFactory : IPageViewModelFactory
    {
        private readonly IWeddingConfig weddingConfig;

        public PageViewModelFactory(IWeddingConfig weddingConfig)
        {
            this.weddingConfig = weddingConfig;
        }

        public TPageViewModel GetPageViewModel<TPageViewModel>(
            UserViewModel user,
            HeaderImageViewModel headerImage,
            string pageLink,
            string title = null,
            string subtitle = null,
            string buttonUrl = null,
            string buttonText = null) where TPageViewModel : PageViewModelBase, new()
        {
            var model = new TPageViewModel();
            return PreparePageViewModel(model, user, headerImage, pageLink, title, subtitle, buttonUrl, buttonText);
        }

        public TPageViewModel PreparePageViewModel<TPageViewModel>(
            TPageViewModel model,
            UserViewModel user,
            HeaderImageViewModel headerImage,
            string pageLink,
            string title = null,
            string subtitle = null,
            string buttonUrl = null,
            string buttonText = null) where TPageViewModel : PageViewModelBase, new()
        {
            var applicationTitle = string.Format("{0} & {1}", Resources.WeddingPartyMember_Bride, Resources.WeddingPartyMember_Groom);
            var applicationSubTitle = string.Format("{0} {1}", Resources.Rsvp_Date_Long, Resources.Rsvp_Venue);

            headerImage.Title = title ?? applicationTitle;
            headerImage.SubTitle = subtitle ?? applicationSubTitle;
            headerImage.ButtonUrl = buttonUrl;
            headerImage.ButtonText = buttonText;

            model.ApplicationTitle = applicationTitle;
            model.ApplicationSubTitle = applicationSubTitle;
            model.Header = new HeaderViewModel { PageLink = pageLink, HeaderImage = headerImage };
            model.User = user;
            model.Footer = new FooterViewModel
                           {
                               SocialCircles =
                                   new[]
                                   {
                                       new SocialCircleViewModel(weddingConfig.Twitter, SocialCircleType.Twitter),
                                       new SocialCircleViewModel(weddingConfig.Facebook, SocialCircleType.Facebook),
                                       new SocialCircleViewModel(weddingConfig.GooglePlus, SocialCircleType.GooglePlus),
                                       new SocialCircleViewModel(weddingConfig.GitHub, SocialCircleType.GitHub),
                                       new SocialCircleViewModel(weddingConfig.LinkedIn, SocialCircleType.LinkedIn),
                                       new SocialCircleViewModel(weddingConfig.Email, SocialCircleType.Email)
                                   }
                           };
            return model;
        }
    }
}
