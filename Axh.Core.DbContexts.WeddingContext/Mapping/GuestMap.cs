namespace Axh.Core.DbContexts.WeddingContext.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using Axh.Core.DomainModels.Accounts;

    public class GuestMap : EntityTypeConfiguration<Guest>
    {
        public GuestMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.ToTable("Guests");

            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.UserId).HasColumnName("UserId");

            this.Property(x => x.FirstName).HasColumnName("FirstName").HasMaxLength(128);
            this.Property(x => x.Surname).HasColumnName("Surname").HasMaxLength(128);
            this.Property(x => x.GuestType).HasColumnName("GuestType");

            this.HasRequired(x => x.User).WithMany(x => x.Guests);
        }
    }
}
