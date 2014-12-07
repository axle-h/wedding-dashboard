namespace Axh.Wedding.Application.Contracts.ViewModelServices.Admin
{
    using Axh.Wedding.Application.ViewModels.Admin;

    public interface IAdminViewModelService
    {
        AdminPageViewModel GetAdminPageViewModel(string user);
    }
}