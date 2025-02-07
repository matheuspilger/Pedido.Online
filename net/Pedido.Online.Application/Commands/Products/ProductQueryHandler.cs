using MediatR;
using Pedido.Online.Application.Commands.Products.Actions.Queries;
using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Domain.Core.Bases.Interfaces;
using Pedido.Online.Domain.Entities.ProductAggregate;
using Pedido.Online.Domain.Repositories.Interfaces.Products;

namespace Pedido.Online.Application.Commands.Products
{
    public class ProductQueryHandler(IProductReadRepository productReadRepository) :
        IRequestHandler<ProductGetAllQuery, IResponseResult>,
        IRequestHandler<ProductGetByIdQuery, IResponseResult>
    {
        public async Task<IResponseResult> Handle(ProductGetAllQuery request, CancellationToken token)
        {
            var products = await productReadRepository.GetAll(request.IsActive, token);
            return ResponseResult<IReadOnlyCollection<ProductQueryModel>>
                .ReturnSuccess(products.Select(c => new ProductQueryModel().Map(c)).ToList());
        }

        public async Task<IResponseResult> Handle(ProductGetByIdQuery request, CancellationToken token)
        {
            var product = await productReadRepository.Get(request.Id, token);
            return ResponseResult<ProductQueryModel>
                .ReturnSuccess(new ProductQueryModel().Map(product));
        }
    }
}
