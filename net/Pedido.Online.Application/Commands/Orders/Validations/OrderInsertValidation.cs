using Pedido.Online.Application.Commands.Orders.Actions.Commands;

namespace Pedido.Online.Application.Commands.Orders.Validations
{
    public class OrderInsertValidation : OrderValidation<OrderInsertCommand>
    {
        public OrderInsertValidation()
        {
            ValidateCustomerId();
            ValidateStatus();
            ValidateOrderDate();
            ValidateItens();
        }
    }
}
