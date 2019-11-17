using System.Linq;
using System.Threading.Tasks;
using Redmond.Domain.Entities;
using Redmond.Domain.Queries.GetProduct;
using Redmond.Infrastructure.Helpers;
using Redmond.SharedKernel.Interfaces;

namespace Redmond.Application.Queries
{
    public class GetProductQueryHandler : IQueryHandler<GetProductFilter, GetProductResult>
    {
        private readonly IDbContext dbContext;

        public GetProductQueryHandler(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<GetProductResult> HandleAsync(GetProductFilter filter)
        {
            var product = await this.dbContext
                .GetQueryable<Product>()
                .Where(product => product.Id == filter.ProductId)
                .Select(product => new GetProductResult
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Price = product.Price
                })
                .FirstOrDefaultAsync();

            return product;
        }
    }
}
