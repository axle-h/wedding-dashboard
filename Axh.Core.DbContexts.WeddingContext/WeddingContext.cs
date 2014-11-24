namespace Axh.Core.DbContexts.WeddingContext
{
    using System.Data.Entity;
    using DomainModels.Accounts;

    public class WeddingContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
