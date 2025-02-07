using Pedido.Online.Domain.Entities.OrderAggregate;
using Pedido.Online.Domain.Events.OrderEvent.Actions;
using Pedido.Online.Domain.Repositories.Interfaces.Orders;
using Pedido.Online.Infrastructure.Contexts;

namespace Pedido.Online.Infrastructure.Repositories.MongoDb.Orders
{
    public class OrderEventRepository(MongoDbContext mongoDbContext)
        : EventRepository<OrderEvent>(mongoDbContext), IOrderEventRepository
    {
        public async override Task Insert(OrderEvent orderEvent, CancellationToken token)
        {
            await DbContext.Add(orderEvent.GetEntity<Order>(), token);
            await base.Insert(orderEvent, token);
        }

        public override async Task Update(OrderEvent orderEvent, CancellationToken token)
        {
            await DbContext.Update(orderEvent.GetEntity<Order>(), token);
            await base.Update(orderEvent, token);
        }

        public override async Task Delete(OrderEvent orderEvent, CancellationToken token)
        {
            await DbContext.Update(orderEvent.GetEntity<Order>(), token);
            await base.Delete(orderEvent, token);
        }
    }
}
