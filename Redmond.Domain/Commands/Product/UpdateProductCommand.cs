using System;
using Redmond.SharedKernel.Interfaces;

namespace Redmond.Domain.Commands
{
    public class UpdateProductCommand : ICommand
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
