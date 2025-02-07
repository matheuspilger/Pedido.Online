using Pedido.Online.Application.Commands.Products.Actions.Commands;

namespace Pedido.Online.Application.Commands.Products.Validations
{
    public class ProductInsertValidation : ProductValidation<ProductInsertCommand>
    {
        public ProductInsertValidation()
        {
            ValidateName();
            ValidatePrice();
        }
    }
}
