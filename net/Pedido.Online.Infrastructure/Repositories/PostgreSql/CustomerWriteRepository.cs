using Pedido.Online.Domain.Entities.CustomerAggregate;
using Pedido.Online.Domain.Repositories.Interfaces.Customers;
using Pedido.Online.Infrastructure.Contexts;

namespace Pedido.Online.Infrastructure.Repositories.PostgreSql
{
    public class CustomerWriteRepository(PostgreSqlDbContext sqlDbContext)
        : WriteRepository<Customer>(sqlDbContext), ICustomerWriteRepository
    {
    }
}
