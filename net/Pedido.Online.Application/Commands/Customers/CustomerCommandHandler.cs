using MediatR;
using Pedido.Online.Application.Commands.Customers.Actions.Commands;
using Pedido.Online.Application.Commands.Customers.Responses;
using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Domain.Core.Bases.Interfaces;
using Pedido.Online.Domain.Events.CustomerEvent.Actions;
using Pedido.Online.Domain.Factories;
using Pedido.Online.Domain.Repositories.Interfaces.Customers;

namespace Pedido.Online.Application.Commands.Customers
{
    public class CustomerCommandHandler(ICustomerWriteRepository customerWriteRepository, ICustomerReadRepository customerReadRepository) : CommandHandler,
        IRequestHandler<CustomerInsertCommand, IResponseResult>,
        IRequestHandler<CustomerUpdateCommand, IResponseResult>,
        IRequestHandler<CustomerDeleteCommand, IResponseResult>
    {
        public async Task<IResponseResult> Handle(CustomerInsertCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return ResponseResult<CustomerResponse>.ReturnError(request.GetValidation());

            var customer = CustomerFactory.Create(Guid.NewGuid(), request.IsActive, request.Name, request.Email, request.Phone);
            customer.AddDomainEvent(new CustomerInsertEvent(customer));
            customerWriteRepository.Insert(customer);

            if (!await Commit(customerWriteRepository.UnitOfWork))
                return ResponseResult<CustomerResponse>.ReturnError(PersistentResult);

            return ResponseResult<CustomerResponse>.ReturnSuccess(new(customer.Id));
        }

        public async Task<IResponseResult> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return ResponseResult<CustomerResponse>.ReturnError(request.GetValidation());

            var customer = CustomerFactory.Create(request.Id, request.IsActive, request.Name, request.Email, request.Phone);
            customer.AddDomainEvent(new CustomerUpdateEvent(customer));
            customerWriteRepository.Update(customer);

            if (!await Commit(customerWriteRepository.UnitOfWork))
                return ResponseResult<CustomerResponse>.ReturnError(PersistentResult);

            return ResponseResult<CustomerResponse>.ReturnSuccess(new(customer.Id));
        }

        public async Task<IResponseResult> Handle(CustomerDeleteCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return ResponseResult<CustomerResponse>.ReturnError(request.GetValidation());

            var customer = await customerReadRepository.Get(request.Id, cancellationToken);
            customer.Delete();

            customer.AddDomainEvent(new CustomerDeleteEvent(customer));
            customerWriteRepository.Delete(customer);

            if (!await Commit(customerWriteRepository.UnitOfWork))
                return ResponseResult<CustomerResponse>.ReturnError(PersistentResult);

            return ResponseResult<CustomerResponse>.ReturnSuccess(new(customer.Id));
        }
    }
}
