using Pedido.Online.Domain.Core.Bases;

namespace Pedido.Online.Domain.Events.OrderEvent.Actions
{
    public class OrderEvent(EventType eventType, object entity) 
        : Event(eventType, entity)
    {
    }
}