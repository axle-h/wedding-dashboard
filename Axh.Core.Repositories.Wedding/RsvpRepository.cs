namespace Axh.Core.Repositories.Wedding
{
    using System;
    using System.Data.Entity;
    using System.Linq;
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

            var attachedRsvp = context.Rsvps.FirstOrDefault(x => x.Id == rsvp.Id);

            if (attachedRsvp == null)
            {
                return false;
            }

            attachedRsvp.RsvpDate = rsvp.RsvpDate;

            Crud(
                attachedRsvp.Guests,
                rsvp.Guests,
                g => g.Id,
                (g, gg) =>
                {
                    g.FirstName = gg.FirstName;
                    g.Surname = gg.Surname;
                    g.IsAttending = gg.IsAttending;
                    g.DietaryRequirements = gg.DietaryRequirements;
                    g.GuestType = gg.GuestType;
                });

            Crud(
                attachedRsvp.Stories,
                rsvp.Stories,
                s => s.Id,
                (s, ss) =>
                {
                    s.StoryBody = ss.StoryBody;
                    s.StorySubject = ss.StorySubject;
                    s.StoryTitle = ss.StoryTitle;
                });
            
            context.Entry(attachedRsvp).State = EntityState.Modified;
            return await this.SaveAsync(context);
        }

        public async Task<bool> CreateAsync(Rsvp rsvp)
        {
            var context = this.DbContext;
            context.Rsvps.Add(rsvp);
            return await this.SaveAsync(context);
        }
    }
}
