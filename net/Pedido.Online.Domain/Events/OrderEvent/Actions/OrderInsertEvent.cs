using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Domain.Entities.OrderAggregate;

namespace Pedido.Online.Domain.Events.OrderEvent.Actions
{
    public class OrderInsertEvent(Order order) 
        : OrderEvent(EventType.Insert, order)
    {
    }
}
