using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Domain.Entities.OrderAggregate;

namespace Pedido.Online.Domain.Events.OrderEvent.Actions
{
    public class OrderDeleteEvent(Order order)
        : OrderEvent(EventType.Delete, order)
    {
    }
}
