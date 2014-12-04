namespace Axh.Core.DbContexts.WeddingContext
{
    using System.Data.Entity;

    using Axh.Core.DbContexts.Common;
    using Axh.Core.DbContexts.WeddingContext.Mapping;
    using Axh.Core.DomainModels.Wedding;

    using DomainModels.Accounts;

    public class WeddingContext : DbContext
    {
        public WeddingContext()
            : base(ContextNames.Axh.ToString())
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Rsvp> Rsvps { get; set; }

        public DbSet<Guest> Guests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new RoleMap());
            
            modelBuilder.Configurations.Add(new GuestMap());
            modelBuilder.Configurations.Add(new RsvpMap());
            modelBuilder.Configurations.Add(new RsvpStoryMap());

        }
    }
}
