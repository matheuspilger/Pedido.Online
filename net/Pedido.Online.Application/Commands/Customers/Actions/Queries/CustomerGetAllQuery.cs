using Pedido.Online.Domain.Core.Bases;

namespace Pedido.Online.Application.Commands.Customers.Actions.Queries
{
    public record CustomerGetAllQuery(bool IsActive = true) : Query;
}
