using Redmond.SharedKernel.Interfaces;

namespace Redmond.Domain.Queries.GetAllProducts
{
    public class GetAllProductsFilter : IQuery
    {
        public string Name { get; }
        
        public GetAllProductsFilter(string name)
        {
            this.Name = name;
        }
    }
}
