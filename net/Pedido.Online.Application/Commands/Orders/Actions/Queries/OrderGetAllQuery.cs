using Pedido.Online.Domain.Core.Bases;

namespace Pedido.Online.Application.Commands.Orders.Actions.Queries
{
    public record OrderGetAllQuery(bool IsActive = true) : Query;
}
