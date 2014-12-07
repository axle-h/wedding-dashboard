namespace Axh.Wedding.Application.Contracts.ViewModelServices.Admin
{
    using System.Threading.Tasks;
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Admin;

    public interface IAdminViewModelService
    {
        Task<AdminPageViewModel> GetAdminPageViewModel(UserViewModel user);
    }
}