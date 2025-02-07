using Pedido.Online.Domain.Core.Bases;

namespace Pedido.Online.Application.Commands.Customers.Actions.Queries
{
    public record CustomerGetByIdQuery(Guid Id) : Query;
}
