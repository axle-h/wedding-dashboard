namespace Axh.Core.Repositories.Wedding.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Axh.Core.DomainModels.Wedding;

    public interface IRsvpRepository
    {
        Task<Rsvp> GetRsvpByIdAsync(Guid id);

        Task<bool> UpdateAsync(Rsvp rsvp);

        Task<bool> CreateAsync(Rsvp rsvp);

        Task<IList<Rsvp>> GetAllRsvpsAsync();
    }
}