using MediatR;
using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Domain.Events.CustomerEvent.Actions;
using Pedido.Online.Domain.Repositories.Interfaces.Customers;

namespace Pedido.Online.Domain.Events.CustomerEvent
{
    public class CustomerEventHandler(ICustomerEventRepository customerEventRepository) :
        INotificationHandler<CustomerInsertEvent>,
        INotificationHandler<CustomerUpdateEvent>,
        INotificationHandler<CustomerDeleteEvent>
    {
        public async Task Handle(CustomerInsertEvent customerEvent, CancellationToken token)
        {
            await customerEventRepository.Insert(customerEvent, token);
        }

        public async Task Handle(CustomerUpdateEvent customerEvent, CancellationToken token)
        {
            await customerEventRepository.Update(customerEvent, token);
        }

        public async Task Handle(CustomerDeleteEvent customerEvent, CancellationToken token)
        {
            await customerEventRepository.Delete(customerEvent, token);
        }
    }
}
