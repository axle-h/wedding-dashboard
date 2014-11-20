namespace Axh.Wedding.Application.ViewModelFactories
{
    using Axh.Wedding.Application.Contracts.Config;
    using Axh.Wedding.Application.Contracts.ViewModelFactories;
    using Axh.Wedding.Application.ViewModels.Page;

    public class PageViewModelFactory : IPageViewModelFactory
    {
        private readonly IWeddingConfig weddingConfig;

        public PageViewModelFactory(IWeddingConfig weddingConfig)
        {
            this.weddingConfig = weddingConfig;
        }

        public TPageViewModel GetPageViewModel<TPageViewModel>(
            HeaderImageViewModel headerImage,
            string pageLink,
            string title = null,
            string subtitle = null,
            string buttonUrl = null,
            string buttonText = null) where TPageViewModel : PageViewModelBase, new()
        {
            var applicationTitle = string.Format("{0} & {1}", weddingConfig.Bride, weddingConfig.Groom);
            var applicationSubTitle = string.Format("{0} {1}", weddingConfig.Date.ToString("dddd d MMMM yyyy h tt"), weddingConfig.Venue);
            return new TPageViewModel
                   {
                       ApplicationTitle = applicationTitle,
                       ApplicationSubTitle = applicationSubTitle,
                       Header = new HeaderViewModel
                                {
                                    PageLink = pageLink,
                                    HeaderImage = headerImage,
                                    PageTitle = title ?? applicationTitle,
                                    PageSubTitle = subtitle ?? applicationSubTitle,
                                    ButtonUrl = buttonUrl,
                                    ButtonText = buttonText
                                }
                   };
        }
    }
}
