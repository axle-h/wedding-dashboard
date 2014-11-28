namespace Axh.Wedding.Application.ViewModelFactories
{
    using Axh.Wedding.Application.Contracts.Config;
    using Axh.Wedding.Application.Contracts.ViewModelFactories;
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Page;

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
            var applicationTitle = string.Format("{0} & {1}", weddingConfig.Bride, weddingConfig.Groom);
            var applicationSubTitle = string.Format("{0} {1}", weddingConfig.Date.ToString("dddd d MMMM yyyy h tt"), weddingConfig.Venue);

            headerImage.Title = title ?? applicationTitle;
            headerImage.SubTitle = subtitle ?? applicationSubTitle;
            headerImage.ButtonUrl = buttonUrl;
            headerImage.ButtonText = buttonText;

            return new TPageViewModel
                   {
                       ApplicationTitle = applicationTitle,
                       ApplicationSubTitle = applicationSubTitle,
                       Header = new HeaderViewModel { PageLink = pageLink, HeaderImage = headerImage },
                       User = user,
                       Footer = new FooterViewModel
                                {
                                    EmailAddress = weddingConfig.Email,
                                    FacebookLink = "https://www.facebook.com/" + weddingConfig.Facebook,
                                    GitHubLink ="https://github.com/" + weddingConfig.GitHub,
                                    GooglePlusLink = "https://plus.google.com/" + weddingConfig.GooglePlus,
                                    LinkedInLink = "https://www.linkedin.com/" + weddingConfig.LinkedIn,
                                    TwitterLink = "https://twitter.com/" + weddingConfig.Twitter
                                }
                   };
        }
    }
}
