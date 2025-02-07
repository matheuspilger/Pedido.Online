using Pedido.Online.Domain.Core.Bases;

namespace Pedido.Online.Application.Commands.Products.Actions.Queries
{
    public record ProductGetAllQuery(bool IsActive = true) : Query;
}
