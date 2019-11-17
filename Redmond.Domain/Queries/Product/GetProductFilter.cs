using System;
using Redmond.SharedKernel.Interfaces;

namespace Redmond.Domain.Queries.GetProduct
{
    public class GetProductFilter : IQuery
    {
        public Guid ProductId { get; }
        
        public GetProductFilter(Guid productId)
        {
            this.ProductId = productId;
        }
    }
}
