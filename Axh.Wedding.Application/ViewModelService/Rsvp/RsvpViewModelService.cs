namespace Axh.Wedding.Application.ViewModelService.Rsvp
{
    using System;
    using System.Threading.Tasks;

    using Axh.Core.Services.Rsvp.Contracts;
    using Axh.Wedding.Application.Contracts.Config;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Rsvp;
    using Axh.Wedding.Application.Contracts.ViewModelServices.Rsvp;
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

        public async Task<RsvpPageViewModel> GetRsvpPageViewModel(string user, bool isAdmin, Guid userId)
        {
            var rsvp = await this.rsvpService.GetRsvpByUserIdAsync(userId);

            return this.rsvpViewModelFactory.GetRsvpPageViewModel(user, isAdmin, rsvp);
        }

        public RsvpPageViewModel GetRsvpPageViewModel(string user, bool isAdmin, RsvpPageViewModel model)
        {
            return this.rsvpViewModelFactory.PrepareRsvpPageViewModel(user, isAdmin, model);
        }

        public async Task<bool> UpdateRsvp(Guid userId, RsvpPageViewModel model)
        {
            var rsvp = this.rsvpViewModelFactory.GetRsvp(userId, model);
            return await this.rsvpService.UpdateRsvp(rsvp, this.weddingConfig.AllowAddingGuests);
        }
    }
}
