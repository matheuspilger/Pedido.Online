using FluentValidation.Results;
using MediatR;
using Pedido.Online.Domain.Core.Bases.Interfaces;

namespace Pedido.Online.Domain.Core.Bases
{
    public abstract class Command : IRequest<IResponseResult>, IBaseRequest
    {
        public Guid Id { get; protected set; }
        public bool IsActive { get; set; }
        protected ValidationResult ValidationResult { get; set; }

        public ValidationResult GetValidation() => ValidationResult;
        public virtual bool IsValid() => ValidationResult.IsValid;
    }
}
