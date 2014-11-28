namespace Axh.Wedding.Mvc.Infrastructure.HttpModule
{
    using System.Data.Entity;
    using System.Web;

    using Axh.Core.DbContexts.WeddingContext;

    public class DatabaseInitializerHttpModule : IHttpModule
    {
        private readonly IDatabaseInitializer<WeddingContext> databaseInitializer;

        public DatabaseInitializerHttpModule(IDatabaseInitializer<WeddingContext> databaseInitializer)
        {
            this.databaseInitializer = databaseInitializer;
        }

        public void Init(HttpApplication context)
        {
            Database.SetInitializer(databaseInitializer);
        }

        public void Dispose()
        {
            // Nothing to dispose.
        }
    }
}