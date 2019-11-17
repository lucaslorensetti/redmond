using System;

namespace Redmond.Domain.Queries.GetProduct
{
    public class GetProductResult
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
