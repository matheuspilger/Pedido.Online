using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Infrastructure.Contexts;
using Pedido.Online.Domain.Core.Bases.Interfaces.Repositories;
using Pedido.Online.Domain.Core.Bases.Interfaces;

namespace Pedido.Online.Infrastructure.Repositories.PostgreSql
{
    public class WriteRepository<T>(PostgreSqlDbContext sqlDbContext) : IWriteRepository<T> where T : AggregateRoot
    {
        public IUnitOfWork UnitOfWork => sqlDbContext;

        public void Insert(T entity)
        {
            sqlDbContext.Add(entity);
        }

        public void Update(T entity)
        {
            sqlDbContext.Update(entity);
        }

        public void Delete(T entity)
        {
            sqlDbContext.Update(entity);
        }

        public void Dispose()
        {
            sqlDbContext.Dispose();
        }
    }
}
