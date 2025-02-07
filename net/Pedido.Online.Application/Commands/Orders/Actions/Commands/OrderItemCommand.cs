namespace Pedido.Online.Application.Commands.Orders.Actions.Commands
{
    public class OrderItemCommand
    {
        public Guid Id { get; }
        public Guid ProductId { get; }
        public string ProductName { get; }
        public decimal Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
    }
}
