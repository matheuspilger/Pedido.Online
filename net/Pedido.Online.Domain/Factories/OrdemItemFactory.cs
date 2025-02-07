using Pedido.Online.Domain.Entities.OrderAggregate;

namespace Pedido.Online.Domain.Factories
{
    public class OrdemItemFactory
    {
        public static OrderItem Create(Guid id, Guid productId, string productName, decimal quantity, decimal unitPrice)
            => new(id, productId, productName, quantity, unitPrice);
    }
}
