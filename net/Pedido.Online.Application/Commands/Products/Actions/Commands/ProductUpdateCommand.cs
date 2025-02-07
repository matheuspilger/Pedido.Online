using Pedido.Online.Application.Commands.Products.Validations;

namespace Pedido.Online.Application.Commands.Products.Actions.Commands
{
    public class ProductUpdateCommand : ProductCommand
    {
        public ProductUpdateCommand(Guid id, bool isActive, string name, decimal price)
        {
            Id = id;
            IsActive = isActive;
            Name = name;
            Price = price;
        }

        public override bool IsValid()
        {
            ValidationResult = new ProductUpdateValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
