using MediatR;
using Pedido.Online.Application.Commands.Orders.Actions.Queries;
using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Domain.Core.Bases.Interfaces;
using Pedido.Online.Domain.Entities.OrderAggregate;
using Pedido.Online.Domain.Repositories.Interfaces.Orders;

namespace Pedido.Online.Application.Commands.Orders
{
    public class OrderQueryHandler(IOrderReadRepository orderReadRepository) :
        IRequestHandler<OrderGetAllQuery, IResponseResult>,
        IRequestHandler<OrderGetByIdQuery, IResponseResult>
    {
        public async Task<IResponseResult> Handle(OrderGetAllQuery request, CancellationToken token)
        {
            var orders = await orderReadRepository.GetAll(request.IsActive, token);
            return ResponseResult<IReadOnlyCollection<OrderQueryModel>>
                .ReturnSuccess(orders.Select(c => new OrderQueryModel().Map(c)).ToList());
        }

        public async Task<IResponseResult> Handle(OrderGetByIdQuery request, CancellationToken token)
        {
            var order = await orderReadRepository.Get(request.Id, token);
            return ResponseResult<OrderQueryModel>
                .ReturnSuccess(new OrderQueryModel().Map(order));
        }
    }
}
