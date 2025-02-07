using MediatR;
using Pedido.Online.Application.Commands.Customers.Actions.Queries;
using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Domain.Core.Bases.Interfaces;
using Pedido.Online.Domain.Entities.CustomerAggregate;
using Pedido.Online.Domain.Repositories.Interfaces.Customers;

namespace Pedido.Online.Application.Commands.Customers
{
    public class CustomerQueryHandler(ICustomerReadRepository customerReadRepository) :
        IRequestHandler<CustomerGetAllQuery, IResponseResult>,
        IRequestHandler<CustomerGetByIdQuery, IResponseResult>
    {
        public async Task<IResponseResult> Handle(CustomerGetAllQuery request, CancellationToken token)
        {
            var customers = await customerReadRepository.GetAll(request.IsActive, token);
            return ResponseResult<IReadOnlyCollection<CustomerQueryModel>>
                .ReturnSuccess(customers.Select(c => new CustomerQueryModel().Map(c)).ToList());
        }

        public async Task<IResponseResult> Handle(CustomerGetByIdQuery request, CancellationToken token)
        {
            var customer = await customerReadRepository.Get(request.Id, token);
            return ResponseResult<CustomerQueryModel>
                .ReturnSuccess(new CustomerQueryModel().Map(customer));
        }
    }
}
