namespace Axh.Core.DbContexts.Common.Activators
{
    using System.Data.Entity;
    using Contracts.Activators;

    public class DefaultDbContextActivator<TContext> : IDbContextActivator<TContext> where TContext : DbContext, new()
    {
        private readonly TContext contextInstance;

        private bool isDisposed;

        public DefaultDbContextActivator()
        {
            isDisposed = false;
            contextInstance = new TContext();
        }

        public TContext Instance
        {
            get { return contextInstance; }
        }

        public void Dispose()
        {
            lock (contextInstance)
            {
                if (isDisposed)
                {
                    return;
                }

                this.contextInstance.Dispose();
                this.isDisposed = true;
            }
        }
    }
}
