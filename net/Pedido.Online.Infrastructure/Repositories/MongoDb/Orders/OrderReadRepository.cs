using Pedido.Online.Domain.Entities.OrderAggregate;
using Pedido.Online.Domain.Repositories.Interfaces.Orders;
using Pedido.Online.Infrastructure.Contexts;

namespace Pedido.Online.Infrastructure.Repositories.MongoDb.Orders
{
    public class OrderReadRepository(MongoDbContext mongoDbContext)
        : ReadRepository<Order>(mongoDbContext), IOrderReadRepository
    {
    }
}
