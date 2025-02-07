using Pedido.Online.Domain.Entities.ProductAggregate;
using Pedido.Online.Domain.Repositories.Interfaces.Products;
using Pedido.Online.Infrastructure.Contexts;

namespace Pedido.Online.Infrastructure.Repositories.MongoDb.Products
{
    public class ProductReadRepository(MongoDbContext mongoDbContext)
        : ReadRepository<Product>(mongoDbContext), IProductReadRepository
    {
    }
}
