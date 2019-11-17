using System;

namespace Redmond.Domain.Queries.GetAllProducts
{
    public class GetAllProductsResult
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
