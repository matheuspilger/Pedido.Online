using Pedido.Online.Application.Commands.Orders.Validations;

namespace Pedido.Online.Application.Commands.Orders.Actions.Commands
{
    public class OrderUpdateCommand : OrderCommand
    {
        public OrderUpdateCommand(Guid id, bool isActive, Guid customerId, DateTime orderDate, int status, List<OrderItemCommand> itens)
        {
            Id = id;
            IsActive = isActive;
            CustomerId = customerId;
            OrderDate = orderDate;
            Status = status;
            Itens = itens;
        }

        public override bool IsValid()
        {
            ValidationResult = new OrderUpdateValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
