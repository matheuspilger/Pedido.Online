using Pedido.Online.Domain.Core.Bases;

namespace Pedido.Online.Application.Commands.Orders.Actions.Commands
{
    public abstract class OrderCommand : Command
    {
        public Guid CustomerId { get; protected set; }
        public int Status { get; protected set; }
        public DateTime OrderDate { get; protected set; }
        public List<OrderItemCommand> Itens { get; protected set; }
        public decimal TotalAmount { get; protected set; }
    }
}
