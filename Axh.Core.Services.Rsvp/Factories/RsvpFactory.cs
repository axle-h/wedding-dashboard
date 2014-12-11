namespace Axh.Core.Services.Rsvp.Factories
{
    using Axh.Core.DomainModels.Accounts;
    using Axh.Core.DomainModels.Wedding;
    using Axh.Core.Services.Rsvp.Contracts.Factories;

    public class RsvpFactory : IRsvpFactory
    {
        public RsvpGuest CreateRsvpGuestFromGuest(Guest guest)
        {
            return new RsvpGuest { FirstName = guest.FirstName, Surname = guest.Surname, GuestType = guest.GuestType, IsAttending = false };
        }
    }
}
