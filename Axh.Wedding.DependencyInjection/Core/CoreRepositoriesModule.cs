namespace Axh.Wedding.DependencyInjection.Core
{
    using Axh.Core.Repositories.Wedding;
    using Axh.Core.Repositories.Wedding.Contracts;

    using Ninject.Modules;

    public class CoreRepositoriesModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUserRepository>().To<UserRepository>();
            this.Bind<IUserRoleRepository>().To<UserRoleRepository>();
        }
    }
}
