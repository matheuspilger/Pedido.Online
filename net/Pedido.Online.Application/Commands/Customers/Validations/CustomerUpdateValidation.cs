using Pedido.Online.Application.Commands.Customers.Actions.Commands;

namespace Pedido.Online.Application.Commands.Customers.Validations
{
    public class CustomerUpdateValidation : CustomerValidation<CustomerUpdateCommand>
    {
        public CustomerUpdateValidation()
        {
            ValidateId();
            ValidateName();
            ValidateEmail();
            ValidatePhone();
        }
    }
}
