namespace Axh.Core.Services.Rsvp.Contracts.Factories
{
    using Axh.Core.DomainModels.Accounts;
    using Axh.Core.DomainModels.Wedding;

    public interface IRsvpFactory
    {
        RsvpGuest CreateRsvpGuestFromGuest(Guest guest);
    }
}