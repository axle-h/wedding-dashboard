namespace Axh.Core.DbContexts.WeddingContext.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using Axh.Core.DomainModels.Wedding;

    public class RsvpMap : EntityTypeConfiguration<Rsvp>
    {
        public RsvpMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.ToTable("Wedding_Rsvps");

            this.Property(t => t.Id).HasColumnName("Id");

            this.Property(x => x.RsvpDate).HasColumnName("RsvpDate");

            this.HasRequired(x => x.User).WithOptional(x => x.Rsvp);

            this.HasMany(x => x.Guests).WithRequired(x => x.Rsvp);
        }
    }
}
