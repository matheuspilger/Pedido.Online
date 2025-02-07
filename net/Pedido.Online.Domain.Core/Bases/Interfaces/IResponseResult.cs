using FluentValidation.Results;

namespace Pedido.Online.Domain.Core.Bases.Interfaces
{
    public interface IResponseResult
    {
        int StatusCode { get; }
        object Result { get; }
        ValidationResult Validation { get; }
    }
}
