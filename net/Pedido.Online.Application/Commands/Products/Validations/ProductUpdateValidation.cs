using Pedido.Online.Application.Commands.Products.Actions.Commands;

namespace Pedido.Online.Application.Commands.Products.Validations
{
    public class ProductUpdateValidation : ProductValidation<ProductUpdateCommand>
    {
        public ProductUpdateValidation()
        {
            ValidateId();
            ValidateName();
            ValidatePrice();
        }
    }
}
