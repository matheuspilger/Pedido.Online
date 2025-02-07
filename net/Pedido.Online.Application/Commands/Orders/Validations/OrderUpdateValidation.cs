using Pedido.Online.Application.Commands.Orders.Actions.Commands;

namespace Pedido.Online.Application.Commands.Orders.Validations
{
    public class OrderUpdateValidation : OrderValidation<OrderUpdateCommand>
    {
        public OrderUpdateValidation()
        {
            ValidateId();
            ValidateCustomerId();
            ValidateStatus();
            ValidateOrderDate();
            ValidateItens();
        }
    }
}
