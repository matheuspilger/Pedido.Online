using FluentValidation;
using Pedido.Online.Application.Commands.Products.Actions.Commands;

namespace Pedido.Online.Application.Commands.Products.Validations
{
    public abstract class ProductValidation<T> : AbstractValidator<T> where T : ProductCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome do produto não informado.")
                .Length(2, 150).WithMessage("O nome do produto não pode ser menor que 2 caracteres nem maior que 150 caracteres.");
        }

        protected void ValidatePrice()
        {
            RuleFor(c => c.Price)
                .GreaterThan(decimal.Zero).WithMessage("Preço do produto é inválido");
        }
    }
}
