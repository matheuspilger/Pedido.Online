using Pedido.Online.Domain.Core.Bases.Interfaces.Repositories;
using Pedido.Online.Domain.Events.ProductEvent.Actions;

namespace Pedido.Online.Domain.Repositories.Interfaces.Products
{
    public interface IProductEventRepository : IEventRepository<ProductEvent>
    {
    }
}
