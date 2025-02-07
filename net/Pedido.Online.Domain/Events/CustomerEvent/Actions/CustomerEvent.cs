using Pedido.Online.Domain.Core.Bases;

namespace Pedido.Online.Domain.Events.CustomerEvent.Actions
{
    public class CustomerEvent(EventType eventType, object entity) 
        : Event(eventType, entity)
    {
    }
}