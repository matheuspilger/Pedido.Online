using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Domain.Entities.ProductAggregate;

namespace Pedido.Online.Domain.Events.ProductEvent.Actions
{
    public class ProductInsertEvent(Product product) 
        : ProductEvent(EventType.Insert, product)
    {
    }
}
