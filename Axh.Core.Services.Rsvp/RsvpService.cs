namespace Axh.Core.Services.Rsvp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Axh.Core.Repositories.Wedding.Contracts;

    using Axh.Core.DomainModels.Wedding;
    using Axh.Core.Services.Rsvp.Contracts;
    using Axh.Core.Services.Rsvp.Contracts.Factories;

    public class RsvpService : IRsvpService
    {
        private readonly IRsvpRepository rsvpRepository;

        private readonly IGuestRepository guestRepository;

        private readonly IRsvpFactory rsvpFactory;

        public RsvpService(IRsvpRepository rsvpRepository, IGuestRepository guestRepository, IRsvpFactory rsvpFactory)
        {
            this.rsvpRepository = rsvpRepository;
            this.guestRepository = guestRepository;
            this.rsvpFactory = rsvpFactory;
        }

        public async Task<Rsvp> GetRsvpByUserIdAsync(Guid userId)
        {
            var rsvp = await this.rsvpRepository.GetRsvpByIdAsync(userId);
            
            if(rsvp != null)
            {
                return rsvp;
            }

            var guests = await this.guestRepository.GetUserGuestsAsync(userId);

            // Create a blank one.
            return new Rsvp { Id = userId, Guests = guests.Select(this.rsvpFactory.CreateRsvpGuestFromGuest).ToList(), Stories = Enumerable.Empty<RsvpStory>().ToList() };
        }

        public async Task<bool> UpdateRsvp(Rsvp rsvp)
        {
            var existingRsvp = await this.rsvpRepository.GetRsvpByIdAsync(rsvp.Id);

            rsvp.RsvpDate = DateTime.UtcNow;

            if (existingRsvp != null)
            {
                return await this.rsvpRepository.UpdateAsync(rsvp);
            }

            return await this.rsvpRepository.CreateAsync(rsvp);
        }

        public async Task<IList<Rsvp>> GetAllRsvpsAsync()
        {
            return await this.rsvpRepository.GetAllRsvpsAsync();
        }
    }
}
