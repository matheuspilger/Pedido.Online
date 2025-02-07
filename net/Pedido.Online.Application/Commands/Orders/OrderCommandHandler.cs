using MediatR;
using Pedido.Online.Application.Commands.Orders.Actions.Commands;
using Pedido.Online.Application.Commands.Orders.Responses;
using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Domain.Core.Bases.Interfaces;
using Pedido.Online.Domain.Entities.OrderAggregate.Enums;
using Pedido.Online.Domain.Events.OrderEvent.Actions;
using Pedido.Online.Domain.Factories;
using Pedido.Online.Domain.Repositories.Interfaces.Orders;

namespace Pedido.Online.Application.Commands.Orders
{
    public class OrderCommandHandler(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository) : CommandHandler,
        IRequestHandler<OrderInsertCommand, IResponseResult>,
        IRequestHandler<OrderUpdateCommand, IResponseResult>,
        IRequestHandler<OrderDeleteCommand, IResponseResult>
    {
        public async Task<IResponseResult> Handle(OrderInsertCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return ResponseResult<OrderResponse>.ReturnError(request.GetValidation());

            var order = OrderFactory.Create(Guid.NewGuid(), request.IsActive, request.CustomerId, request.OrderDate, (OrderStatus)request.Status);
            request.Itens.ForEach(item => order.ProcessItem(
                item.Id, item.ProductId, item.ProductName, item.Quantity, item.UnitPrice));
            order.Calculate();

            order.AddDomainEvent(new OrderInsertEvent(order));
            orderWriteRepository.Insert(order);

            if (!await Commit(orderWriteRepository.UnitOfWork))
                return ResponseResult<OrderResponse>.ReturnError(PersistentResult);

            return ResponseResult<OrderResponse>.ReturnSuccess(new(order.Id));
        }

        public async Task<IResponseResult> Handle(OrderUpdateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return ResponseResult<OrderResponse>.ReturnError(request.GetValidation());

            var order = OrderFactory.Create(request.Id, request.IsActive, request.CustomerId, request.OrderDate, (OrderStatus)request.Status);
            request.Itens.ForEach(item => order.ProcessItem(
                item.Id, item.ProductId, item.ProductName, item.Quantity, item.UnitPrice));
            order.Calculate();

            order.AddDomainEvent(new OrderUpdateEvent(order));
            orderWriteRepository.Update(order);

            if (!await Commit(orderWriteRepository.UnitOfWork))
                return ResponseResult<OrderResponse>.ReturnError(PersistentResult);

            return ResponseResult<OrderResponse>.ReturnSuccess(new(order.Id));
        }

        public async Task<IResponseResult> Handle(OrderDeleteCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return ResponseResult<OrderResponse>.ReturnError(request.GetValidation());

            var order = await orderReadRepository.Get(request.Id, cancellationToken);
            order.AddDomainEvent(new OrderDeleteEvent(order));
            orderWriteRepository.Delete(order);

            if (!await Commit(orderWriteRepository.UnitOfWork))
                return ResponseResult<OrderResponse>.ReturnError(PersistentResult);

            return ResponseResult<OrderResponse>.ReturnSuccess(new(order.Id));
        }
    }
}
