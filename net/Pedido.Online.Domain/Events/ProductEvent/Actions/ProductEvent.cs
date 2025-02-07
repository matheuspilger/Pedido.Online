using Pedido.Online.Domain.Core.Bases;

namespace Pedido.Online.Domain.Events.ProductEvent.Actions
{
    public class ProductEvent(EventType eventType, object entity) 
        : Event(eventType, entity)
    {
    }
}