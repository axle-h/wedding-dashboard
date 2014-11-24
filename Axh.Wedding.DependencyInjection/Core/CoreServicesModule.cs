namespace Axh.Wedding.DependencyInjection.Core
{
    using System.Configuration;
    using Axh.Core.Services.Logging;
    using Axh.Core.Services.Logging.Contracts;
    using Ninject.Modules;

    public class CoreServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILoggingService>().To<Log4NetLoggingService>().WithConstructorArgument("name", x => "Wedding");
        }
    }
}
