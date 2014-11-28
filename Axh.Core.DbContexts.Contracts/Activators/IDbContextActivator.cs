namespace Axh.Core.DbContexts.Contracts.Activators
{
    using System.Data.Entity;

    public interface IDbContextActivator<out TContext> where TContext : DbContext, new()
    {
        TContext Instance { get; }

        void Dispose();
    }
}