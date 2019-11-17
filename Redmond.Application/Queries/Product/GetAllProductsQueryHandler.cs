using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Redmond.Domain.Entities;
using Redmond.Domain.Queries.GetAllProducts;
using Redmond.Infrastructure.Helpers;
using Redmond.SharedKernel.Interfaces;

namespace Redmond.Application.Queries
{
    public class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsFilter, IEnumerable<GetAllProductsResult>>
    {
        private readonly IDbContext dbContext;

        public GetAllProductsQueryHandler(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<GetAllProductsResult>> HandleAsync(GetAllProductsFilter filter)
        {
            var products = this.dbContext.GetQueryable<Product>();

            if (!string.IsNullOrWhiteSpace(filter?.Name))
            {
                products = products.Where(product => product.Name.Contains(filter.Name));
            }

            var selectedProducts = products.Select(product => new GetAllProductsResult
            {
                ProductId = product.Id,
                Name = product.Name,
                Price = product.Price
            });

            return await selectedProducts.ToListAsync();
        }
    }
}
