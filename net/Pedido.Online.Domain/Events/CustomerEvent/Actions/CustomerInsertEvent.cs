using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Domain.Entities.CustomerAggregate;

namespace Pedido.Online.Domain.Events.CustomerEvent.Actions
{
    public class CustomerInsertEvent(Customer customer) 
        : CustomerEvent(EventType.Insert, customer)
    {
    }
}
