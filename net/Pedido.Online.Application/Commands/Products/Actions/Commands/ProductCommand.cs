using Pedido.Online.Domain.Core.Bases;

namespace Pedido.Online.Application.Commands.Products.Actions.Commands
{
    public abstract class ProductCommand : Command
    {
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
    }
}
