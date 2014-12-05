namespace Axh.Wedding.Mvc.Infrastructure.HttpModule
{
    using System.Data.Entity;
    using System.Web;

    using Axh.Core.DbContexts.WeddingContext;
    using Axh.Wedding.Application.Contracts.Config;

    public class DatabaseInitializerHttpModule : IHttpModule
    {
        private readonly IDatabaseInitializer<WeddingContext> databaseInitializer;

        private readonly IWeddingConfig weddingConfig;

        public DatabaseInitializerHttpModule(IDatabaseInitializer<WeddingContext> databaseInitializer, IWeddingConfig weddingConfig)
        {
            this.databaseInitializer = databaseInitializer;
            this.weddingConfig = weddingConfig;
        }

        public void Init(HttpApplication context)
        {
            if (weddingConfig.RunDatabaseInitializer)
            {
                Database.SetInitializer(databaseInitializer);
            }
        }

        public void Dispose()
        {
            // Nothing to dispose.
        }
    }
}