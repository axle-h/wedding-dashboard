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

        public TPageViewModel GetPageViewModel<TPageViewModel>(string headerBackgroundUrl, bool headerTextIsLight, string title = null, string subtitle = null) where TPageViewModel : PageViewModelBase, new()
        {
            var applicationTitle = string.Format("{0} & {1}", weddingConfig.Bride, weddingConfig.Groom);
            var applicationSubTitle = string.Format("{0} {1}", weddingConfig.Date.ToString("dddd d MMMM yyyy h tt"), weddingConfig.Venue);
            return new TPageViewModel
                   {
                       ApplicationTitle = applicationTitle,
                       ApplicationSubTitle = applicationSubTitle,
                       Header = new HeaderViewModel
                                {
                                    HeaderBackgroundUrl = headerBackgroundUrl,
                                    PageTitle = title ?? applicationTitle,
                                    PageSubTitle = subtitle ?? applicationSubTitle,
                                    IsLight = headerTextIsLight
                                }
                   };
        }
    }
}
