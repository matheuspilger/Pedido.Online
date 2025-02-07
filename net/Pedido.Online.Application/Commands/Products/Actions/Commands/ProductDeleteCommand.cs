using Pedido.Online.Application.Commands.Products.Validations;
using Pedido.Online.Domain.Core.Bases;

namespace Pedido.Online.Application.Commands.Products.Actions.Commands
{
    public class ProductDeleteCommand : Command
    {
        public new Guid Id { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new ProductDeleteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
