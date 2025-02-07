using FluentValidation;
using Pedido.Online.Application.Commands.Orders.Actions.Commands;

namespace Pedido.Online.Application.Commands.Orders.Validations
{
    public abstract class OrderValidation<T> : AbstractValidator<T> where T : OrderCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateCustomerId()
        {
            RuleFor(c => c.CustomerId)
                .NotEqual(Guid.Empty).WithMessage("O pedido não possui nenhum consumidor.");
        }

        protected void ValidateStatus()
        {
            RuleFor(c => c.Status)
                .NotEqual(0).WithMessage("O status do pedido é inválido.");
        }

        protected void ValidateOrderDate()
        {
            RuleFor(c => c.OrderDate)
                .NotEqual(DateTime.MinValue).WithMessage("A data do pedido é inválida.");
        }

        protected void ValidateItens()
        {
            RuleFor(c => c.Itens)
                .NotEmpty().WithMessage("O pedido não possui nenhum item.");
        }
    }
}
