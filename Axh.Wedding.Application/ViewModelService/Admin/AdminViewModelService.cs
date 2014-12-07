namespace Axh.Wedding.Application.ViewModelService.Admin
{
    using System.Threading.Tasks;
    using Axh.Wedding.Application.Contracts.Services;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Admin;
    using Axh.Wedding.Application.Contracts.ViewModelServices.Admin;
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Admin;

    public class AdminViewModelService : IAdminViewModelService
    {
        private readonly IAdminViewModelFactory adminViewModelFactory;

        private readonly IWeddingUserService weddingUserService;

        public AdminViewModelService(IAdminViewModelFactory adminViewModelFactory, IWeddingUserService weddingUserService)
        {
            this.adminViewModelFactory = adminViewModelFactory;
            this.weddingUserService = weddingUserService;
        }

        public async Task<AdminPageViewModel> GetAdminPageViewModel(UserViewModel user)
        {
            var users = await this.weddingUserService.GetAllWeddingUsersAsync();

            return this.adminViewModelFactory.GetAdminPageViewModel(user, users);
        }
    }
}
