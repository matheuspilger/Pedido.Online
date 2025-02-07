using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Domain.Entities.ProductAggregate;

namespace Pedido.Online.Domain.Events.ProductEvent.Actions
{
    public class ProductUpdateEvent(Product product)
        : ProductEvent(EventType.Update, product)
    {
    }
}
