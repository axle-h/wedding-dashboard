namespace Axh.Core.Services.Rsvp.Factories
{
    using Axh.Core.DomainModels.Accounts;
    using Axh.Core.DomainModels.Wedding;
    using Axh.Core.Services.Rsvp.Contracts.Factories;

    public class RsvpFactory : IRsvpFactory
    {
        public RsvpGuest GetRsvpGuest(Guest guest)
        {
            return new RsvpGuest { Id = guest.Id, FirstName = guest.FirstName, Surname = guest.Surname, IsAttending = false };
        }
    }
}
