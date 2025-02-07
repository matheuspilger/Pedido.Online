using Pedido.Online.Domain.Core.Bases;

namespace Pedido.Online.Application.Commands.Orders.Actions.Queries
{
    public record OrderGetByIdQuery(Guid Id) : Query;
}
