namespace Axh.Core.DbContexts.WeddingContext
{
    using System.Data.Entity;

    using Axh.Core.DbContexts.Common;
    using Axh.Core.DbContexts.WeddingContext.Mapping;

    using DomainModels.Accounts;

    public class WeddingContext : DbContext
    {
        public WeddingContext()
            : base(ContextNames.Axh.ToString())
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserRoleMap());
        }
    }
}
