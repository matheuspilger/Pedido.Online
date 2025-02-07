namespace Pedido.Online.Domain.Core.Bases.Interfaces.Repositories
{
    public interface IReadRepository<T> where T : AggregateRoot
    {
        Task<IReadOnlyCollection<T>> GetAll(bool isActive, CancellationToken token);
        Task<T> Get(Guid id, CancellationToken token);
    }
}
