using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Domain.Entities.CustomerAggregate;

namespace Pedido.Online.Domain.Events.CustomerEvent.Actions
{
    public class CustomerDeleteEvent(Customer customer)
        : CustomerEvent(EventType.Delete, customer)
    {
    }
}
