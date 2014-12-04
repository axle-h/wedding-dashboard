namespace Axh.Core.Services.Rsvp
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Axh.Core.Repositories.Wedding.Contracts;

    using Axh.Core.DomainModels.Wedding;
    using Axh.Core.Services.Rsvp.Contracts;

    public class RsvpService : IRsvpService
    {
        private readonly IRsvpRepository rsvpRepository;

        private readonly IGuestRepository guestRepository;

        public RsvpService(IRsvpRepository rsvpRepository, IGuestRepository guestRepository)
        {
            this.rsvpRepository = rsvpRepository;
            this.guestRepository = guestRepository;
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
            return new Rsvp { Id = userId, Guests = guests, Stories = Enumerable.Empty<RsvpStory>().ToList() };
        }

        public async Task<bool> UpdateRsvp(Rsvp rsvp)
        {
            var existingRsvp = await this.rsvpRepository.GetRsvpByIdAsync(rsvp.Id);

            if (existingRsvp == null)
            {
                return await this.rsvpRepository.CreateAsync(rsvp);
            }

            return await this.rsvpRepository.UpdateAsync(rsvp);
        }
    }
}
