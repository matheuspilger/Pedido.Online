using Pedido.Online.Domain.Entities.ProductAggregate;
using Pedido.Online.Domain.Repositories.Interfaces.Products;
using Pedido.Online.Infrastructure.Contexts;

namespace Pedido.Online.Infrastructure.Repositories.PostgreSql
{
    public class ProductWriteRepository(PostgreSqlDbContext sqlDbContext)
        : WriteRepository<Product>(sqlDbContext), IProductWriteRepository
    {
    }
}
