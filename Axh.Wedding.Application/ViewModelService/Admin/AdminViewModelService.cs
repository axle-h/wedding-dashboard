namespace Axh.Wedding.Application.ViewModelService.Admin
{
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Admin;
    using Axh.Wedding.Application.Contracts.ViewModelServices.Admin;
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Admin;

    public class AdminViewModelService : IAdminViewModelService
    {
        private readonly IAdminViewModelFactory adminViewModelFactory;

        public AdminViewModelService(IAdminViewModelFactory adminViewModelFactory)
        {
            this.adminViewModelFactory = adminViewModelFactory;
        }

        public AdminPageViewModel GetAdminPageViewModel(UserViewModel user)
        {
            return this.adminViewModelFactory.GetAdminPageViewModel(user);
        }
    }
}
