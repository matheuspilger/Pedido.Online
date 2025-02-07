using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Domain.Entities.OrderAggregate.Enums;
using Pedido.Online.Domain.Factories;
namespace Pedido.Online.Domain.Entities.OrderAggregate
{
    public class Order : AggregateRoot
    {
        public Order(Guid id, bool isActive, Guid customerId, DateTime orderDate, OrderStatus status)
        {
            Id = id;
            IsActive = isActive;
            CustomerId = customerId;
            OrderDate = orderDate;
            Status = status;
        }

        public Guid CustomerId { get; }
        public OrderStatus Status { get; }
        public DateTime OrderDate { get; }
        public List<OrderItem> Itens { get; private set; }
        public decimal TotalAmount { get; private set; }

        public void ProcessItem(Guid id, Guid productId, string productName, decimal quantity, decimal price)
        {
            Itens ??= [];

            var itemExists = Itens.FirstOrDefault(x => x.Id == id);
            if(itemExists is null)
            {
                var item = OrdemItemFactory.Create(id, productId, productName, quantity, price);
                Itens.Add(item.Calculate());
            }
            else
            {
                var itemIndex = Itens.IndexOf(itemExists);
                Itens[itemIndex] = itemExists.Update(quantity, price).Calculate();
            }
        }
            

        public void Calculate()
            => TotalAmount = Itens.Sum(x => x.TotalPrice);
    }
}
