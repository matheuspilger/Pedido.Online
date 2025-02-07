using Pedido.Online.Application.Commands.Customers.Validations;

namespace Pedido.Online.Application.Commands.Customers.Actions.Commands
{
    public class CustomerInsertCommand : CustomerCommand
    {
        public CustomerInsertCommand(bool isActive, string name, string email, string phone)
        {
            IsActive = isActive;
            Name = name;
            Email = email;
            Phone = phone;
        }

        public override bool IsValid()
        {
            ValidationResult = new CustomerInsertValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
