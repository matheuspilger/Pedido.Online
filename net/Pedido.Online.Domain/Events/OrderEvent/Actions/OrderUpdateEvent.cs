using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Domain.Entities.OrderAggregate;

namespace Pedido.Online.Domain.Events.OrderEvent.Actions
{
    public class OrderUpdateEvent(Order order)
        : OrderEvent(EventType.Update, order)
    {
    }
}
