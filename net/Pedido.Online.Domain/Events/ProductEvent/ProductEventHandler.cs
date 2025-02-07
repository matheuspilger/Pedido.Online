using MediatR;
using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Domain.Events.ProductEvent.Actions;
using Pedido.Online.Domain.Repositories.Interfaces.Products;

namespace Pedido.Online.Domain.Events.ProductEvent
{
    public class ProductEventHandler(IProductEventRepository productEventRepository) :
        INotificationHandler<ProductInsertEvent>,
        INotificationHandler<ProductUpdateEvent>,
        INotificationHandler<ProductDeleteEvent>
    {
        public async Task Handle(ProductInsertEvent productEvent, CancellationToken token)
        {
            await productEventRepository.Insert(productEvent, token);
        }

        public async Task Handle(ProductUpdateEvent productEvent, CancellationToken token)
        {
            await productEventRepository.Update(productEvent, token);
        }

        public async Task Handle(ProductDeleteEvent productEvent, CancellationToken token)
        {
            await productEventRepository.Delete(productEvent, token);
        }
    }
}
