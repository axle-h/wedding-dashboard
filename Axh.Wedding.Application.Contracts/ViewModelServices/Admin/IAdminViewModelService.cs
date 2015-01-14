namespace Axh.Wedding.Application.Contracts.ViewModelServices.Admin
{
    using System;
    using System.Threading.Tasks;
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Admin;

    public interface IAdminViewModelService
    {
        Task<AdminPageViewModel> GetAdminPageViewModel(UserViewModel user);

        Task<EditUserPageViewModel> GetEditUserPageViewModel(UserViewModel user, Guid userId);

        Task<bool> DeleteUser(Guid userId);

        Task<bool> EditUser(EditUserPageViewModel model);

        Task<AdminRsvpPageViewModel> GetAdminRsvpPageViewModel(UserViewModel user, Guid userId);
    }
}