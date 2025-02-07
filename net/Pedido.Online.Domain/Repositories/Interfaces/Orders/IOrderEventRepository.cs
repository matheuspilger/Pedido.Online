using Pedido.Online.Domain.Core.Bases.Interfaces.Repositories;
using Pedido.Online.Domain.Events.OrderEvent.Actions;

namespace Pedido.Online.Domain.Repositories.Interfaces.Orders
{
    public interface IOrderEventRepository : IEventRepository<OrderEvent>
    {
    }
}
