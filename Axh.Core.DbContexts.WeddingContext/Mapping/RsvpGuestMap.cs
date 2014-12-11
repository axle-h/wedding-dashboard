namespace Axh.Core.DbContexts.WeddingContext.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using Axh.Core.DomainModels.Wedding;

    public class RsvpGuestMap : EntityTypeConfiguration<RsvpGuest>
    {
        public RsvpGuestMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.ToTable("Wedding_Guests");

            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            this.Property(x => x.FirstName).HasColumnName("FirstName").HasMaxLength(128);
            this.Property(x => x.Surname).HasColumnName("Surname").HasMaxLength(128);
            this.Property(x => x.IsAttending).HasColumnName("IsAttending");
            this.Property(x => x.DietaryRequirements).HasColumnName("DietaryRequirements");
        }
    }
}
