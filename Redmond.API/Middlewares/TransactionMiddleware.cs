using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Redmond.SharedKernel.Interfaces;

namespace Redmond.API.Middlewares
{
    public class TransactionMiddleware
    {
        private readonly RequestDelegate next;

        public TransactionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext, IDbContext dbContext)
        {
            await next(httpContext);

            if (!await dbContext.HasChangesAsync())
            {
                return;
            }

            try
            {
                await dbContext.BeginTransactionAsync();

                await dbContext.SaveChangesAsync();

                await dbContext.CommitTransactionAsync();
            }
            catch (Exception)
            {
                await dbContext.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
