using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Domain.Entities.CustomerAggregate;

namespace Pedido.Online.Application.Commands.Customers.Actions.Queries
{
    public class CustomerQueryModel : QueryModel<Customer>
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }

        public override CustomerQueryModel Map(Customer entity)
        {
            return new CustomerQueryModel
            {
                Id = entity.Id,
                IsActive = entity.IsActive,
                Name = entity.Name,
                Email = entity.Email,
                Phone = entity.Phone
            };
        }
    }
}
