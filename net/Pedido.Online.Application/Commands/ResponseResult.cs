using FluentValidation.Results;
using Pedido.Online.Domain.Core.Bases.Interfaces;

namespace Pedido.Online.Application.Commands
{
    public enum ResponseResultStatus
    {
        Success = 200,
        Error = 404
    }

    public class ResponseResult<T>(ResponseResultStatus status, T result = default, ValidationResult validation = default) : IResponseResult
    {
        public int StatusCode { get; } = (int) status;
        public object Result { get; } = result;
        public ValidationResult Validation { get; } = validation;

        public static ResponseResult<T> ReturnSuccess(T result)
            => new(ResponseResultStatus.Success, result: result);

        public static ResponseResult<T> ReturnError(ValidationResult validation)
            => new(ResponseResultStatus.Error, validation: validation);
    }
}