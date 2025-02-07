using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Domain.Entities.ProductAggregate;

namespace Pedido.Online.Application.Commands.Products.Actions.Queries
{
    public class ProductQueryModel : QueryModel<Product>
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public override ProductQueryModel Map(Product entity)
        {
            return new ProductQueryModel
            {
                Id = entity.Id,
                IsActive = entity.IsActive,
                Name = entity.Name,
                Price = entity.Price
            };
        }
    }
}
