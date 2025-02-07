namespace Pedido.Online.Domain.Core.Bases.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
