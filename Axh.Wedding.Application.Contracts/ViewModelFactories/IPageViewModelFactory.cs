namespace Axh.Wedding.Application.Contracts.ViewModelFactories
{
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Page;

    public interface IPageViewModelFactory
    {
        TPageViewModel GetPageViewModel<TPageViewModel>(
            UserViewModel user,
            HeaderImageViewModel headerImage,
            string pageLink,
            string title = null,
            string subtitle = null,
            string buttonUrl = null,
            string buttonText = null) where TPageViewModel : PageViewModelBase, new();
    }
}