using Pedido.Online.Domain.Core.Bases;

namespace Pedido.Online.Domain.Entities.CustomerAggregate
{
    public class Customer : AggregateRoot
    {
        public Customer(Guid id, bool isActive, string name, string email, string phone)
        {
            Id = id;
            IsActive = isActive;
            Name = name;
            Email = email;
            Phone = phone;
        }

        public string Name { get; }
        public string Email { get; }
        public string Phone { get; }
    }
}
