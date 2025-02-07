using MediatR;
using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Domain.Events.OrderEvent.Actions;
using Pedido.Online.Domain.Repositories.Interfaces.Orders;

namespace Pedido.Online.Domain.Events.OrderEvent
{
    public class OrderEventHandler(IOrderEventRepository orderEventRepository) :
        INotificationHandler<OrderInsertEvent>,
        INotificationHandler<OrderUpdateEvent>,
        INotificationHandler<OrderDeleteEvent>
    {
        public async Task Handle(OrderInsertEvent orderEvent, CancellationToken token)
        {
            await orderEventRepository.Insert(orderEvent, token);
        }

        public async Task Handle(OrderUpdateEvent orderEvent, CancellationToken token)
        {
            await orderEventRepository.Update(orderEvent, token);
        }

        public async Task Handle(OrderDeleteEvent orderEvent, CancellationToken token)
        {
            await orderEventRepository.Delete(orderEvent, token);
        }
    }
}
