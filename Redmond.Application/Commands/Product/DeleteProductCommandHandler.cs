using System.Linq;
using System.Threading.Tasks;
using Redmond.Domain.Commands;
using Redmond.Domain.Entities;
using Redmond.Infrastructure.Helpers;
using Redmond.SharedKernel.Dtos;
using Redmond.SharedKernel.Interfaces;

namespace Redmond.Application.Commands
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
    {
        private readonly IDbContext dbContext;

        public DeleteProductCommandHandler(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<OperationResult> HandleAsync(DeleteProductCommand command)
        {
            var product = await this.dbContext
                .GetQueryable<Product>()
                .Where(product => product.Id == command.ProductId)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return new OperationResult(true);
            }

            await this.dbContext.DeleteAsync(product);

            return new OperationResult();
        }
    }
}
