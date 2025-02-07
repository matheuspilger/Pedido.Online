using Pedido.Online.Domain.Entities.CustomerAggregate;
using Pedido.Online.Domain.Repositories.Interfaces.Customers;
using Pedido.Online.Infrastructure.Contexts;

namespace Pedido.Online.Infrastructure.Repositories.MongoDb.Customers
{
    public class CustomerReadRepository(MongoDbContext mongoDbContext)
        : ReadRepository<Customer>(mongoDbContext), ICustomerReadRepository
    {
    }
}
