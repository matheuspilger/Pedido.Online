using Pedido.Online.Domain.Core.Bases.Interfaces.Repositories;
using Pedido.Online.Domain.Events.CustomerEvent.Actions;

namespace Pedido.Online.Domain.Repositories.Interfaces.Customers
{
    public interface ICustomerEventRepository : IEventRepository<CustomerEvent>
    {
    }
}
