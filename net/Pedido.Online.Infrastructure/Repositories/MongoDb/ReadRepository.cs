using Pedido.Online.Domain.Core.Bases.Interfaces.Repositories;
using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Infrastructure.Contexts;

namespace Pedido.Online.Infrastructure.Repositories.MongoDb
{
    public class ReadRepository<T>(MongoDbContext mongoDbContext) : IReadRepository<T> where T : AggregateRoot
    {
        public async Task<T> Get(Guid id, CancellationToken token)
        {
            return await mongoDbContext.Get<T>(id, token);
        }

        public async Task<IReadOnlyCollection<T>> GetAll(bool isActive, CancellationToken token)
        {
            return await mongoDbContext.GetAll<T>(isActive, token);
        }
    }
}
