using Pedido.Online.Application.Commands.Customers.Actions.Commands;

namespace Pedido.Online.Application.Commands.Customers.Validations
{
    public class CustomerInsertValidation : CustomerValidation<CustomerInsertCommand>
    {
        public CustomerInsertValidation()
        {
            ValidateName();
            ValidateEmail();
            ValidatePhone();
        }
    }
}
