using Pedido.Online.Application.Commands.Customers.Validations;

namespace Pedido.Online.Application.Commands.Customers.Actions.Commands
{
    public class CustomerUpdateCommand : CustomerCommand
    {
        public CustomerUpdateCommand(Guid id, bool isActive, string name, string email, string phone)
        {
            Id = id;
            IsActive = isActive;
            Name = name;
            Email = email;
            Phone = phone;
        }

        public override bool IsValid()
        {
            ValidationResult = new CustomerUpdateValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
