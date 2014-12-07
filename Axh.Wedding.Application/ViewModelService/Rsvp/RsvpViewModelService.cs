namespace Axh.Wedding.Application.ViewModelService.Rsvp
{
    using System.Threading.Tasks;

    using Axh.Core.Services.Rsvp.Contracts;
    using Axh.Wedding.Application.Contracts.Config;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Rsvp;
    using Axh.Wedding.Application.Contracts.ViewModelServices.Rsvp;
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Rsvp;

    public class RsvpViewModelService : IRsvpViewModelService
    {
        private readonly IRsvpViewModelFactory rsvpViewModelFactory;

        private readonly IRsvpService rsvpService;

        private readonly IWeddingConfig weddingConfig;

        public RsvpViewModelService(IRsvpViewModelFactory rsvpViewModelFactory, IRsvpService rsvpService, IWeddingConfig weddingConfig)
        {
            this.rsvpViewModelFactory = rsvpViewModelFactory;
            this.rsvpService = rsvpService;
            this.weddingConfig = weddingConfig;
        }

        public async Task<RsvpPageViewModel> GetRsvpPageViewModel(UserViewModel user)
        {
            var rsvp = await this.rsvpService.GetRsvpByUserIdAsync(user.UserId);

            return this.rsvpViewModelFactory.GetRsvpPageViewModel(user, rsvp);
        }

        public RsvpPageViewModel GetRsvpPageViewModel(UserViewModel user, RsvpPageViewModel model)
        {
            return this.rsvpViewModelFactory.PrepareRsvpPageViewModel(user, model);
        }

        public async Task<bool> UpdateRsvp(UserViewModel user, RsvpPageViewModel model)
        {
            var rsvp = this.rsvpViewModelFactory.GetRsvp(user.UserId, model);
            return await this.rsvpService.UpdateRsvp(rsvp, this.weddingConfig.AllowAddingGuests);
        }
    }
}
