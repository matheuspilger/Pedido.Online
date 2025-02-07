using FluentValidation;
using Pedido.Online.Application.Commands.Customers.Actions.Commands;

namespace Pedido.Online.Application.Commands.Customers.Validations
{
    public abstract class CustomerValidation<T> : AbstractValidator<T> where T : CustomerCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome do consumidor não informado.")
                .Length(2, 100).WithMessage("O nome do consumidor não pode ser menor que 2 caracteres nem maior que 100 caracteres.");
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress().WithMessage("Email do consumidor é inválido");
        }

        protected void ValidatePhone()
        {
            RuleFor(c => c.Phone)
                .NotEmpty().MinimumLength(11).WithMessage("Telefone do consumidor é inválido.");
        }
    }
}
