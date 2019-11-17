using Redmond.SharedKernel.Interfaces;

namespace Redmond.Domain.Commands
{
    public class CreateProductCommand : ICommand
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
