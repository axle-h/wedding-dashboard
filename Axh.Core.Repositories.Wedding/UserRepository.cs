namespace Axh.Core.Repositories.Wedding
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Threading.Tasks;

    using Axh.Core.DbContexts.Contracts.Activators;
    using Axh.Core.DbContexts.WeddingContext;
    using Axh.Core.DomainModels.Accounts;
    using Axh.Core.Repositories.Common;
    using Axh.Core.Repositories.Wedding.Contracts;
    using Axh.Core.Services.Logging.Contracts;

    public class UserRepository : RepositoryBase<WeddingContext>, IUserRepository
    {
        public UserRepository(IDbContextActivator<WeddingContext> dbContextActivator, ILoggingService loggingService) : base(dbContextActivator, loggingService)
        {
        }

        public async Task<bool> CreateAsync(User user)
        {
            var context = this.DbContext;
            context.Users.Add(user);
            context.Configuration.ValidateOnSaveEnabled = false;
            return await this.SaveAsync(context);
        }

        public async Task<bool> UpdateAsync(User user)
        {
            var context = this.DbContext;
            context.Users.Attach(user);
            context.Entry(user).State = EntityState.Modified;
            context.Configuration.ValidateOnSaveEnabled = false;
            return await this.SaveAsync(context);
        }

        public async Task<bool> DeleteAsync(User user)
        {
            var context = this.DbContext;
            context.Users.Remove(user);
            context.Configuration.ValidateOnSaveEnabled = false;
            return await this.SaveAsync(context);
        }

        public async Task<User> FindByIdAsync(Guid userId)
        {
            return await this.DbContext.Users.FindAsync(userId);
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            return await this.DbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await this.DbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<IList<User>> GetAllAsync()
        {
            return await this.DbContext.Users.ToListAsync();
        }
    }
}
