using Pedido.Online.Domain.Entities.OrderAggregate;
using Pedido.Online.Domain.Repositories.Interfaces.Orders;
using Pedido.Online.Infrastructure.Contexts;

namespace Pedido.Online.Infrastructure.Repositories.PostgreSql
{
    public class OrderWriteRepository(PostgreSqlDbContext sqlDbContext)
        : WriteRepository<Order>(sqlDbContext), IOrderWriteRepository
    {
    }
}
