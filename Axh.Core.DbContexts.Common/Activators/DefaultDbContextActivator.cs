namespace Axh.Core.DbContexts.Common.Activators
{
    using System.Data.Entity;
    using Contracts.Activators;

    public class DefaultDbContextActivator<TContext> : IDbContextActivator<TContext> where TContext : DbContext, new()
    {
        private readonly TContext contextInstance;

        public DefaultDbContextActivator()
        {
            contextInstance = new TContext();
        }

        public TContext Instance
        {
            get { return contextInstance; }
        }
    }
}
