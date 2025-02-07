using FluentValidation;
using Pedido.Online.Application.Commands.Customers.Actions.Commands;

namespace Pedido.Online.Application.Commands.Customers.Validations
{
    public class CustomerDeleteValidation : AbstractValidator<CustomerDeleteCommand>
    {
        public CustomerDeleteValidation()
        {
            ValidateId();
        }
        private void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
