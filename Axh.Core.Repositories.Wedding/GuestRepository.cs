namespace Axh.Core.Repositories.Wedding
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    using Axh.Core.DbContexts.Contracts.Activators;
    using Axh.Core.DbContexts.WeddingContext;
    using Axh.Core.DomainModels.Wedding;
    using Axh.Core.Repositories.Common;
    using Axh.Core.Repositories.Wedding.Contracts;
    using Axh.Core.Services.Logging.Contracts;

    public class GuestRepository : RepositoryBase<WeddingContext>, IGuestRepository
    {
        public GuestRepository(IDbContextActivator<WeddingContext> dbContextActivator, ILoggingService loggingService)
            : base(dbContextActivator, loggingService)
        {
        }

        public async Task<IList<Guest>> GetUserGuestsAsync(Guid userId)
        {
            var context = this.DbContext;

            return await context.Guests.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
