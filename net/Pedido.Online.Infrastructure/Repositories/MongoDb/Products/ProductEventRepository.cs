using Pedido.Online.Domain.Entities.ProductAggregate;
using Pedido.Online.Domain.Events.ProductEvent.Actions;
using Pedido.Online.Domain.Repositories.Interfaces.Products;
using Pedido.Online.Infrastructure.Contexts;

namespace Pedido.Online.Infrastructure.Repositories.MongoDb.Products
{
    public class ProductEventRepository(MongoDbContext mongoDbContext)
        : EventRepository<ProductEvent>(mongoDbContext), IProductEventRepository
    {
        public async override Task Insert(ProductEvent productEvent, CancellationToken token)
        {
            await DbContext.Add(productEvent.GetEntity<Product>(), token);
            await base.Insert(productEvent, token);
        }

        public override async Task Update(ProductEvent productEvent, CancellationToken token)
        {
            await DbContext.Update(productEvent.GetEntity<Product>(), token);
            await base.Update(productEvent, token);
        }

        public override async Task Delete(ProductEvent productEvent, CancellationToken token)
        {
            await DbContext.Update(productEvent.GetEntity<Product>(), token);
            await base.Delete(productEvent, token);
        }
    }
}
