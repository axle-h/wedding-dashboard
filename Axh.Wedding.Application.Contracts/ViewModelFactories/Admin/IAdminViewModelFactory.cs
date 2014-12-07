namespace Axh.Wedding.Application.Contracts.ViewModelFactories.Admin
{
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Admin;

    public interface IAdminViewModelFactory
    {
        AdminPageViewModel GetAdminPageViewModel(UserViewModel user);
        AdminPageViewModel PrepareAdminPageViewModel(UserViewModel user, AdminPageViewModel viewModel);
    }
}