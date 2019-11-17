using System.Linq;
using System.Threading.Tasks;
using Redmond.Domain.Commands;
using Redmond.Domain.Entities;
using Redmond.Infrastructure.Helpers;
using Redmond.SharedKernel.Dtos;
using Redmond.SharedKernel.Interfaces;

namespace Redmond.Application.Commands
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
    {
        private readonly IDbContext dbContext;

        public UpdateProductCommandHandler(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<OperationResult> HandleAsync(UpdateProductCommand command)
        {
            var product = await this.dbContext
                .GetQueryable<Product>()
                .Where(product => product.Id == command.ProductId)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return new OperationResult(true);
            }

            product.Name = command.Name;
            product.Price = command.Price;

            await this.dbContext.UpdateAsync(product);

            return new OperationResult(product.Id);
        }
    }
}
