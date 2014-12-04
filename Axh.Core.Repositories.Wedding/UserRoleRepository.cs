namespace Axh.Core.Repositories.Wedding
{
    using System.Data.Entity;
    using System.Threading.Tasks;

    using Axh.Core.DbContexts.Contracts.Activators;
    using Axh.Core.DbContexts.WeddingContext;
    using Axh.Core.DomainModels.Accounts;
    using Axh.Core.Repositories.Common;
    using Axh.Core.Repositories.Wedding.Contracts;
    using Axh.Core.Services.Logging.Contracts;

    public class UserRoleRepository : RepositoryBase<WeddingContext>, IUserRoleRepository
    {
        public UserRoleRepository(IDbContextActivator<WeddingContext> dbContextActivator, ILoggingService loggingService)
            : base(dbContextActivator, loggingService)
        {
        }

        public async Task<Role> FindByNameAsync(string roleName)
        {
            return await this.DbContext.Roles.FirstOrDefaultAsync(x => x.RoleName == roleName);
        }
    }
}
