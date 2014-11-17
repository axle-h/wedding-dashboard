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

        public TPageViewModel GetPageViewModel<TPageViewModel>(string title) where TPageViewModel : PageViewModelBase, new()
        {
            return new TPageViewModel
                   {
                       PageTitle = title,
                       ApplicationTitle = string.Format("{0} & {1}", weddingConfig.Bride, weddingConfig.Groom),
                       ApplicationSubTitle = string.Format("{0} {1}", weddingConfig.Date.ToString("dddd d MMMM yyyy h tt"), weddingConfig.Venue)
                   };
        }
    }
}
