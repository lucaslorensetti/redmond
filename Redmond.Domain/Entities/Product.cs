using Redmond.SharedKernel.Interfaces;
using System;

namespace Redmond.Domain.Entities
{
    public class Product : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
