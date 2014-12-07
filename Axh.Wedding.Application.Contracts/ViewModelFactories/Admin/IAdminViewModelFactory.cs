namespace Axh.Wedding.Application.Contracts.ViewModelFactories.Admin
{
    using System.Collections.Generic;
    using Axh.Wedding.Application.Contracts.Models.Account;
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Admin;

    public interface IAdminViewModelFactory
    {
        AdminPageViewModel GetAdminPageViewModel(UserViewModel user, IEnumerable<WeddingUser> users);
        AdminPageViewModel PrepareAdminPageViewModel(UserViewModel user, AdminPageViewModel viewModel);
    }
}