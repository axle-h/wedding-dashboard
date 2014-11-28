namespace Axh.Wedding.DependencyInjection.Core
{
    using Axh.Core.DbContexts.Common.Activators;
    using Axh.Core.DbContexts.Contracts.Activators;
    using Axh.Core.DbContexts.WeddingContext;

    using Ninject.Modules;

    public class CoreContextsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDbContextActivator<WeddingContext>>().To<DefaultDbContextActivator<WeddingContext>>();
        }
    }
}
