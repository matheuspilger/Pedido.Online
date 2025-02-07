namespace Pedido.Online.Domain.Core.Bases.Interfaces.Repositories
{
    public interface IWriteRepository<T> : IDisposable where T : AggregateRoot
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IUnitOfWork UnitOfWork { get; }
    }
}
