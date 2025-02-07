using Pedido.Online.Domain.Entities.CustomerAggregate;
using Pedido.Online.Domain.Events.CustomerEvent.Actions;
using Pedido.Online.Domain.Repositories.Interfaces.Customers;
using Pedido.Online.Infrastructure.Contexts;

namespace Pedido.Online.Infrastructure.Repositories.MongoDb.Customers
{
    public class CustomerEventRepository(MongoDbContext mongoDbContext)
        : EventRepository<CustomerEvent>(mongoDbContext), ICustomerEventRepository
    {
        public async override Task Insert(CustomerEvent customerEvent, CancellationToken token)
        {
            await DbContext.Add(customerEvent.GetEntity<Customer>(), token);
            await base.Insert(customerEvent, token);
        }

        public override async Task Update(CustomerEvent customerEvent, CancellationToken token)
        {
            await DbContext.Update(customerEvent.GetEntity<Customer>(), token);
            await base.Update(customerEvent, token);
        }

        public override async Task Delete(CustomerEvent customerEvent, CancellationToken token)
        {
            await DbContext.Update(customerEvent.GetEntity<Customer>(), token);
            await base.Delete(customerEvent, token);
        }
    }
}
