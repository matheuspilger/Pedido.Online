using FluentValidation.Results;
using Pedido.Online.Domain.Core.Bases.Interfaces;

namespace Pedido.Online.Domain.Core.Bases
{
    public abstract class CommandHandler
    {
        protected ValidationResult PersistentResult;

        protected CommandHandler()
            => PersistentResult = new ValidationResult();

        private void AddError(string mensagem)
            => PersistentResult.Errors.Add(new(string.Empty, mensagem));

        private async Task<bool> Commit(IUnitOfWork uow, string message)
        {
            if (!await uow.Commit())
                AddError(message);

            return PersistentResult.IsValid;
        }

        protected async Task<bool> Commit(IUnitOfWork uow)
            => await Commit(uow, "Ocorreu um erro ao salvar os dados.").ConfigureAwait(continueOnCapturedContext: false);
    }
}
