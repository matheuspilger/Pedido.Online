using Pedido.Online.Application.Commands.Customers.Validations;
using Pedido.Online.Domain.Core.Bases;

namespace Pedido.Online.Application.Commands.Customers.Actions.Commands
{
    public class CustomerDeleteCommand : Command
    {
        public new Guid Id { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CustomerDeleteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
