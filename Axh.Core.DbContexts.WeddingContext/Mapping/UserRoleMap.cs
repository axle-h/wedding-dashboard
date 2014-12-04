namespace Axh.Core.DbContexts.WeddingContext.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using Axh.Core.DomainModels.Accounts;

    public class UserRoleMap : EntityTypeConfiguration<Role>
    {
        public UserRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.ToTable("Roles");

            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.RoleName).HasColumnName("RoleName");
        }
    }
}
