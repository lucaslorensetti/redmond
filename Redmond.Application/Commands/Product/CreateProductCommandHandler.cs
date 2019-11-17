using System;
using System.Threading.Tasks;
using Redmond.Domain.Commands;
using Redmond.Domain.Entities;
using Redmond.SharedKernel.Dtos;
using Redmond.SharedKernel.Interfaces;

namespace Redmond.Application.Commands
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly IDbContext dbContext;

        public CreateProductCommandHandler(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<OperationResult> HandleAsync(CreateProductCommand command)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Price = command.Price
            };

            await this.dbContext.CreateAsync(product);

            return new OperationResult(product.Id);
        }
    }
}
