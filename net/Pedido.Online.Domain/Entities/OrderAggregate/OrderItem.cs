using Pedido.Online.Domain.Core.Bases;

namespace Pedido.Online.Domain.Entities.OrderAggregate
{
    public class OrderItem
    {
        public OrderItem(Guid id, Guid productId, string productName, decimal quantity, decimal unitPrice)
        {
            Id = id;
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public Guid Id { get; }
        public Guid ProductId { get; }
        public string ProductName { get; }
        public decimal Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice { get; private set; }
        public Guid OrderId { get; }

        public OrderItem Update(decimal quantity, decimal unitPrice)
        {
            Quantity = quantity;
            UnitPrice = unitPrice;
            return this;
        }

        public OrderItem Calculate()
        {
            TotalPrice = UnitPrice * Quantity;
            return this;
        }
    }
}
