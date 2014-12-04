namespace Axh.Wedding.DependencyInjection.Core
{
    using Axh.Core.Services.Logging;
    using Axh.Core.Services.Logging.Contracts;
    using Axh.Core.Services.Rsvp;
    using Axh.Core.Services.Rsvp.Contracts;
    using Axh.Core.Services.User;
    using Axh.Core.Services.User.Contracts;

    using Ninject.Modules;

    public class CoreServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILoggingService>().To<Log4NetLoggingService>().WithConstructorArgument("name", x => "Wedding");
            Bind<IUserService>().To<UserService>();
            Bind<IRsvpService>().To<RsvpService>();
        }
    }
}
