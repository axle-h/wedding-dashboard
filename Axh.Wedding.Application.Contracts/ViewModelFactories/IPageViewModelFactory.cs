namespace Axh.Wedding.Application.Contracts.ViewModelFactories
{
    using Axh.Wedding.Application.ViewModels.Page;

    public interface IPageViewModelFactory
    {
        TPageViewModel GetPageViewModel<TPageViewModel>(string headerBackgroundUrl, bool headerTextIsLight, string title = null, string subtitle = null) where TPageViewModel : PageViewModelBase, new();
    }
}