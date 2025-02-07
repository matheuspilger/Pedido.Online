using Pedido.Online.Application.Commands.Orders.Validations;
using Pedido.Online.Domain.Core.Bases;

namespace Pedido.Online.Application.Commands.Orders.Actions.Commands
{
    public class OrderDeleteCommand : Command
    {
        public new Guid Id { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new OrderDeleteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
