namespace Axh.Core.Services.Rsvp.Contracts
{
    using System;
    using System.Threading.Tasks;

    using Axh.Core.DomainModels.Wedding;

    public interface IRsvpService
    {
        Task<Rsvp> GetRsvpByUserIdAsync(Guid userId);

        Task<bool> UpdateRsvp(Rsvp rsvp, bool allowAddingGuests);
    }
}