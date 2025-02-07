using Pedido.Online.Application.Commands.Products.Validations;

namespace Pedido.Online.Application.Commands.Products.Actions.Commands
{
    public class ProductInsertCommand : ProductCommand
    {
        public ProductInsertCommand(bool isActive, string name, decimal price)
        {
            IsActive = isActive;
            Name = name;
            Price = price;
        }

        public override bool IsValid()
        {
            ValidationResult = new ProductInsertValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
