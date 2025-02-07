using Pedido.Online.Domain.Core.Bases.Interfaces.Repositories;
using Pedido.Online.Domain.Entities.OrderAggregate;

namespace Pedido.Online.Domain.Repositories.Interfaces.Orders
{
    public interface IOrderReadRepository : IReadRepository<Order>
    {
    }
}
