namespace Axh.Core.Repositories.Wedding.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Axh.Core.DomainModels.Wedding;

    public interface IGuestRepository
    {
        Task<IList<Guest>> GetUserGuestsAsync(Guid userId);
    }
}