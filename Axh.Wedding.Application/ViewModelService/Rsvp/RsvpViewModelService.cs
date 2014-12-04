namespace Axh.Wedding.Application.ViewModelService.Rsvp
{
    using System;
    using System.Threading.Tasks;

    using Axh.Core.Services.Rsvp.Contracts;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Rsvp;
    using Axh.Wedding.Application.Contracts.ViewModelServices.Rsvp;
    using Axh.Wedding.Application.ViewModels.Rsvp;

    public class RsvpViewModelService : IRsvpViewModelService
    {
        private readonly IRsvpViewModelFactory rsvpViewModelFactory;

        private readonly IRsvpService rsvpService;

        public RsvpViewModelService(IRsvpViewModelFactory rsvpViewModelFactory, IRsvpService rsvpService)
        {
            this.rsvpViewModelFactory = rsvpViewModelFactory;
            this.rsvpService = rsvpService;
        }

        public async Task<RsvpPageViewModel> GetRsvpPageViewModel(string user, Guid userId)
        {
            var rsvp = await this.rsvpService.GetRsvpByUserIdAsync(userId);

            return this.rsvpViewModelFactory.GetRsvpPageViewModel(user, rsvp);
        }

        public async Task<bool> UpdateRsvp(Guid userId, RsvpPageViewModel model)
        {
            var rsvp = this.rsvpViewModelFactory.GetRsvp(userId, model);
            return await this.rsvpService.UpdateRsvp(rsvp);
        }
    }
}
