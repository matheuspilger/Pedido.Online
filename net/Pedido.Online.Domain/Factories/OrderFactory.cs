using Pedido.Online.Domain.Entities.OrderAggregate;
using Pedido.Online.Domain.Entities.OrderAggregate.Enums;

namespace Pedido.Online.Domain.Factories
{
    public class OrderFactory
    {
        public static Order Create(Guid id, bool isActive, Guid customerId, DateTime orderDate, OrderStatus status)
            => new(id, isActive, customerId, orderDate, status);
    }
}
