using Pedido.Online.Domain.Entities.CustomerAggregate;

namespace Pedido.Online.Domain.Factories
{
    public class CustomerFactory
    {
        public static Customer Create(Guid id, bool isActive, string name, string email, string phone)
            => new(id, isActive, name, email, phone);
    }
}
