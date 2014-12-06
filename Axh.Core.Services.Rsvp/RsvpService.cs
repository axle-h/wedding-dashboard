namespace Axh.Core.Services.Rsvp
{
    using System;
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
            return new Rsvp { Id = userId, Guests = guests.Select(this.rsvpFactory.GetRsvpGuest).ToList(), Stories = Enumerable.Empty<RsvpStory>().ToList() };
        }

        public async Task<bool> UpdateRsvp(Rsvp rsvp, bool allowAddingGuests)
        {
            var newGuests = rsvp.Guests.Where(x => x.Id == Guid.Empty).ToArray();

            if (allowAddingGuests)
            {
                // Make sure that new guests have Id's These aren't auto generated in the db as I have a psudo 1:(1,0) on Guest
                foreach (var guest in newGuests)
                {
                    guest.Id = Guid.NewGuid();
                }
            }
            else
            {
                // Not allowing new guests. Somone has sent in a bad request.
                // Hide our displeasure with their feeble hackery and just remove the new guests.
                // It's also possible that someone loaded their page before the setting was turned off...
                foreach (var guest in newGuests)
                {
                    rsvp.Guests.Remove(guest);
                }
            }

            var existingRsvp = await this.rsvpRepository.GetRsvpByIdAsync(rsvp.Id);

            if (existingRsvp != null)
            {
                return await this.rsvpRepository.UpdateAsync(rsvp);
            }

            rsvp.RsvpDate = DateTime.UtcNow;
            return await this.rsvpRepository.CreateAsync(rsvp);
        }
    }
}
