namespace Axh.Wedding.Application.Contracts.ViewModelFactories.Admin
{
    using Axh.Wedding.Application.ViewModels.Admin;

    public interface IAdminViewModelFactory
    {
        AdminPageViewModel GetAdminPageViewModel(string user);
        AdminPageViewModel PrepareAdminPageViewModel(string user, AdminPageViewModel viewModel);
    }
}