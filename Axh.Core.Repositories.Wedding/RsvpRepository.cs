namespace Axh.Core.Repositories.Wedding
{
    using System;
    using System.Data.Entity;
    using System.Threading.Tasks;

    using Axh.Core.DbContexts.Contracts.Activators;
    using Axh.Core.DbContexts.WeddingContext;
    using Axh.Core.DomainModels.Wedding;
    using Axh.Core.Repositories.Common;
    using Axh.Core.Repositories.Wedding.Contracts;
    using Axh.Core.Services.Logging.Contracts;

    public class RsvpRepository : RepositoryBase<WeddingContext>, IRsvpRepository
    {
        public RsvpRepository(IDbContextActivator<WeddingContext> dbContextActivator, ILoggingService loggingService)
            : base(dbContextActivator, loggingService)
        {
        }

        public async Task<Rsvp> GetRsvpByIdAsync(Guid id)
        {
            var context = this.DbContext;

            return await context.Rsvps.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Rsvp rsvp)
        {
            var context = this.DbContext;
            context.Rsvps.Attach(rsvp);
            context.Entry(rsvp).State = EntityState.Modified;
            context.Configuration.ValidateOnSaveEnabled = false;
            return await this.SaveAsync(context);
        }

        public async Task<bool> CreateAsync(Rsvp rsvp)
        {
            var context = this.DbContext;
            context.Rsvps.Add(rsvp);
            context.Configuration.ValidateOnSaveEnabled = false;
            return await this.SaveAsync(context);
        }
    }
}
