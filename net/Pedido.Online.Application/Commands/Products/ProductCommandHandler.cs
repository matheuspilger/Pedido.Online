using MediatR;
using Pedido.Online.Application.Commands.Products.Actions.Commands;
using Pedido.Online.Application.Commands.Products.Responses;
using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Domain.Core.Bases.Interfaces;
using Pedido.Online.Domain.Events.ProductEvent.Actions;
using Pedido.Online.Domain.Factories;
using Pedido.Online.Domain.Repositories.Interfaces.Products;

namespace Pedido.Online.Application.Commands.Products
{
    public class ProductCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository) : CommandHandler,
        IRequestHandler<ProductInsertCommand, IResponseResult>,
        IRequestHandler<ProductUpdateCommand, IResponseResult>,
        IRequestHandler<ProductDeleteCommand, IResponseResult>
    {
        public async Task<IResponseResult> Handle(ProductInsertCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return ResponseResult<ProductResponse>.ReturnError(request.GetValidation());

            var product = ProductFactory.Create(Guid.NewGuid(), request.IsActive, request.Name, request.Price);
            product.AddDomainEvent(new ProductInsertEvent(product));
            productWriteRepository.Insert(product);

            if (!await Commit(productWriteRepository.UnitOfWork))
                return ResponseResult<ProductResponse>.ReturnError(PersistentResult);

            return ResponseResult<ProductResponse>.ReturnSuccess(new(product.Id));
        }

        public async Task<IResponseResult> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return ResponseResult<ProductResponse>.ReturnError(request.GetValidation());

            var product = ProductFactory.Create(request.Id, request.IsActive, request.Name, request.Price);
            product.AddDomainEvent(new ProductUpdateEvent(product));
            productWriteRepository.Update(product);

            if (!await Commit(productWriteRepository.UnitOfWork))
                return ResponseResult<ProductResponse>.ReturnError(PersistentResult);

            return ResponseResult<ProductResponse>.ReturnSuccess(new(product.Id));
        }

        public async Task<IResponseResult> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return ResponseResult<ProductResponse>.ReturnError(request.GetValidation());

            var product = await productReadRepository.Get(request.Id, cancellationToken);
            product.Delete();

            product.AddDomainEvent(new ProductDeleteEvent(product));
            productWriteRepository.Delete(product);

            if (!await Commit(productWriteRepository.UnitOfWork))
                return ResponseResult<ProductResponse>.ReturnError(PersistentResult);

            return ResponseResult<ProductResponse>.ReturnSuccess(new(product.Id));
        }
    }
}
