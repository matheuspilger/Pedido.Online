using Pedido.Online.Domain.Core.Bases;

namespace Pedido.Online.Application.Commands.Customers.Actions.Commands
{
    public abstract class CustomerCommand : Command
    {
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Phone { get; protected set; }
    }
}
