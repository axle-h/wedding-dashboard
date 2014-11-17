namespace Axh.Wedding.Application.Contracts.ViewModelFactories
{
    using Axh.Wedding.Application.ViewModels.Page;

    public interface IPageViewModelFactory
    {
        TPageViewModel GetPageViewModel<TPageViewModel>(string title) where TPageViewModel : PageViewModelBase, new();
    }
}