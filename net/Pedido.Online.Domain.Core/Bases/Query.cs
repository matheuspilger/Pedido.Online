using MediatR;
using Pedido.Online.Domain.Core.Bases.Interfaces;

namespace Pedido.Online.Domain.Core.Bases
{
    public record Query : IRequest<IResponseResult>;
}
