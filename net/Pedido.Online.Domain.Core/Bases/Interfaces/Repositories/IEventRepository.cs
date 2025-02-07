namespace Pedido.Online.Domain.Core.Bases.Interfaces.Repositories
{
    public interface IEventRepository<T> where T : Event
    {
        Task Insert(T entity, CancellationToken token);
        Task Update(T entity, CancellationToken token);
        Task Delete(T entity, CancellationToken token);
    }
}
