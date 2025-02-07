using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Domain.Entities.OrderAggregate;
using Pedido.Online.Domain.Entities.OrderAggregate.Enums;

namespace Pedido.Online.Application.Commands.Orders.Actions.Queries
{
    public class OrderQueryModel : QueryModel<Order>
    {
        public Guid CustomerId { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime OrderDate { get; private set; }
        public List<OrderItem> Itens { get; private set; }
        public decimal TotalAmount { get; private set; }

        public override OrderQueryModel Map(Order entity)
        {
            return new OrderQueryModel
            {
                Id = entity.Id,
                IsActive = entity.IsActive,
                CustomerId = entity.CustomerId,
                Status = entity.Status,
                OrderDate = entity.OrderDate,
            };
        }
    }
}
