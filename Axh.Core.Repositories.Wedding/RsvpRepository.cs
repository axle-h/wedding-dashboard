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

            // Added guests cab't be removed so we do this in one merge.
            foreach (var match in rsvp.Guests.GroupJoin(attachedRsvp.Guests, n => n.Id, g => g.Id, (n, g) => new { UpdatedGuest = n, ExistingGuest = g.FirstOrDefault() }))
            {
                if (match.ExistingGuest == null)
                {
                    attachedRsvp.Guests.Add(match.UpdatedGuest);
                }
                else
                {
                    match.ExistingGuest.FirstName = match.UpdatedGuest.FirstName;
                    match.ExistingGuest.Surname = match.UpdatedGuest.Surname;
                    match.ExistingGuest.IsAttending = match.UpdatedGuest.IsAttending;
                    match.ExistingGuest.DietaryRequirements = match.UpdatedGuest.DietaryRequirements;
                    match.ExistingGuest.GuestType = match.UpdatedGuest.GuestType;
                }
            }

            // Added stories cab't be removed so we do this in one merge.
            foreach (var match in rsvp.Stories.GroupJoin(attachedRsvp.Stories, n => n.Id, s => s.Id, (n, s) => new { UpdatedStory = n, ExistingStory = s.FirstOrDefault() }))
            {
                if (match.ExistingStory == null)
                {
                    attachedRsvp.Stories.Add(match.UpdatedStory);
                }
                else
                {
                    match.ExistingStory.StoryBody = match.UpdatedStory.StoryBody;
                    match.ExistingStory.StorySubject = match.UpdatedStory.StorySubject;
                    match.ExistingStory.StoryTitle = match.UpdatedStory.StoryTitle;
                }
            }

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
