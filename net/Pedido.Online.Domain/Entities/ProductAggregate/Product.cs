using Pedido.Online.Domain.Core.Bases;

namespace Pedido.Online.Domain.Entities.ProductAggregate
{
    public class Product : AggregateRoot
    {
        public Product(Guid id, bool isActive, string name, decimal price)
        {
            Id = id;
            IsActive = isActive;
            Name = name;
            Price = price;
        }

        public string Name { get; }
        public decimal Price { get; }
    }
}
