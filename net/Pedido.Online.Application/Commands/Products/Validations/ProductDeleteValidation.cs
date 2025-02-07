using FluentValidation;
using Pedido.Online.Application.Commands.Products.Actions.Commands;

namespace Pedido.Online.Application.Commands.Products.Validations
{
    public class ProductDeleteValidation : AbstractValidator<ProductDeleteCommand>
    {
        public ProductDeleteValidation()
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
