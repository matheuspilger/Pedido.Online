using FluentValidation;
using Pedido.Online.Application.Commands.Orders.Actions.Commands;

namespace Pedido.Online.Application.Commands.Orders.Validations
{
    public class OrderDeleteValidation : AbstractValidator<OrderDeleteCommand>
    {
        public OrderDeleteValidation()
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
