using Pedido.Online.Domain.Entities.ProductAggregate;

namespace Pedido.Online.Domain.Factories
{
    public class ProductFactory
    {
        public static Product Create(Guid id, bool isActive, string name, decimal price)
            => new(id, isActive, name, price);
    }
}
