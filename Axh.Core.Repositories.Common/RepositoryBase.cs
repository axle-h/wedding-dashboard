namespace Axh.Core.Repositories.Common
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Threading.Tasks;

    using Axh.Core.DbContexts.Contracts.Activators;
    using Axh.Core.Services.Logging.Contracts;

    public abstract class RepositoryBase<TContext> : IDisposable
        where TContext : DbContext, new()
    {
        private readonly IDbContextActivator<TContext> dbContextActivator;

        private readonly ILoggingService loggingService;

        protected RepositoryBase(IDbContextActivator<TContext> dbContextActivator, ILoggingService loggingService)
        {
            this.dbContextActivator = dbContextActivator;
            this.loggingService = loggingService;
        }


        protected TContext DbContext
        {
            get
            {
                return this.dbContextActivator.Instance;
            }
        }

        private static string GetEntityValidationErrors(DbEntityValidationException ex)
        {
            // Retrieve the error messages as a list of strings.
            var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => "PropertyName: " + x.PropertyName + ", Error: " + x.ErrorMessage);

            // Join the list to a single string.
            var fullErrorMessage = string.Join("; ", errorMessages);

            // Combine the original exception message with the new one.
            var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
            return exceptionMessage;
        }

        protected async Task<bool> SaveAsync(DbContext dbContext)
        {
            try
            {
                return await dbContext.SaveChangesAsync() > 0;
            }
            catch (DbEntityValidationException ex)
            {
                var exceptionMessage = GetEntityValidationErrors(ex);

                this.loggingService.Error(exceptionMessage, ex);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors, ex);
            }
        }

        public void Dispose()
        {
            this.dbContextActivator.Dispose();
        }
    }
}
