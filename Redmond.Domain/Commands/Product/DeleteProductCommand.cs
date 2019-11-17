using System;
using Redmond.SharedKernel.Interfaces;

namespace Redmond.Domain.Commands
{
    public class DeleteProductCommand : ICommand
    {
        public Guid ProductId { get; }


        public DeleteProductCommand(Guid productId)
        {
            this.ProductId = productId;
        }
    }
}
