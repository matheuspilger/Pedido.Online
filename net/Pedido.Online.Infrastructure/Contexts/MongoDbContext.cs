using MongoDB.Driver;
using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Infrastructure.Mappings.MongoDb;

namespace Pedido.Online.Infrastructure.Contexts
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;
        private readonly string _noSqlConnection;

        private IMongoCollection<TEntity> _getCollection<TEntity>() where TEntity : Entity
            => _database.GetCollection<TEntity>(MongoDbMap.GetCollectionName(typeof(TEntity)));

        public static MongoDbContext Initialize(string noSqlConnection, string noSqlDatabase) => 
            new(noSqlConnection, noSqlDatabase);

        public MongoDbContext(string noSqlConnection, string noSqlDatabase)
        {
            MongoDbMap.Configure();
            var mongoClient = new MongoClient(noSqlConnection);
            _database = mongoClient.GetDatabase(noSqlDatabase);
            _noSqlConnection = noSqlConnection;
        }

        public string GetConnectionString() => _noSqlConnection;

        public async Task MigrateDatabase()
        {
            using var asyncCursor = await _database.ListCollectionNamesAsync();
            var collections = await asyncCursor.ToListAsync();

            foreach (var collectionName in MongoDbMap.GetCollectionsNames())
            {
                if (!collections.Exists(db => db.Equals(collectionName, StringComparison.InvariantCultureIgnoreCase)))
                {
                    await _database.CreateCollectionAsync(collectionName, new CreateCollectionOptions
                    {
                        ValidationLevel = DocumentValidationLevel.Strict
                    });
                }
            }
        }

        public async Task<T> Add<T>(T entity, CancellationToken token) where T : Entity
        {
            await _getCollection<T>().InsertOneAsync(entity, cancellationToken: token);
            return entity;
        }

        public async Task<T> Update<T>(T entity, CancellationToken token) where T : Entity
        {
            await _getCollection<T>().ReplaceOneAsync(x => x.Id == entity.Id, entity, cancellationToken: token);
            return entity;
        }

        public async Task<T> Delete<T>(T entity, CancellationToken token) where T: Entity
        {
            await _getCollection<T>().DeleteOneAsync(x => x.Id == entity.Id, cancellationToken: token);
            return entity;
        }

        public async Task<T> Get<T>(Guid id, CancellationToken token) where T: AggregateRoot
        {
            return await _getCollection<T>().Find(x => x.Id == id).FirstOrDefaultAsync(token);
        }

        public async Task<IReadOnlyCollection<T>> GetAll<T>(bool isActive, CancellationToken token) where T : AggregateRoot
        {
            return await _getCollection<T>().Find(x => x.IsActive == isActive).ToListAsync(token);
        }
    }
}
