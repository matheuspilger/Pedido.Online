using Pedido.Online.Domain.Core.Bases.Interfaces.Repositories;
using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Infrastructure.Contexts;

namespace Pedido.Online.Infrastructure.Repositories.MongoDb
{
    public abstract class EventRepository<T>(MongoDbContext mongoDbContext) : IEventRepository<T> where T : Event
    {
        protected MongoDbContext DbContext => mongoDbContext;

        public virtual async Task Insert(T entity, CancellationToken token)
        {
            await mongoDbContext.Add(entity, token);
        }

        public virtual async Task Update(T entity, CancellationToken token)
        {
            await mongoDbContext.Add(entity, token);
        }

        public virtual async Task Delete(T entity, CancellationToken token)
        {
            await mongoDbContext.Add(entity, token);
        }
    }
}
