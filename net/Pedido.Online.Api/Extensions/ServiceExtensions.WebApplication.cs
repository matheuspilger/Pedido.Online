using Microsoft.EntityFrameworkCore;
using Pedido.Online.Infrastructure.Contexts;

namespace Pedido.Online.Api.Extensions
{
    public static partial class ServiceExtensions
    {
        public static async Task RunApp(this WebApplication app)
        {
            using var serviceScope = app.Services.CreateAsyncScope();
            app.Logger.LogInformation("----- Bancos de dados estão sendo migrados....");
            await app.MigrateDataBases(serviceScope);
            app.Logger.LogInformation("----- Os bancos de dados foram migrados com sucesso!");
            app.Logger.LogInformation("----- A API está sendo inicializada...");
            app.Run();
        }

        private static async Task MigrateDataBases(this WebApplication app, IServiceScope serviceScope)
        {
            using var postgreSqlDbContext = serviceScope.ServiceProvider.GetRequiredService<PostgreSqlDbContext>();
            var mongoDbContext = serviceScope.ServiceProvider.GetRequiredService<MongoDbContext>();

            try
            {
                await MigratePostgreSqlDbContext(app, postgreSqlDbContext);
                await MigrateMongoDbContextAsync(app, mongoDbContext);
            }
            catch (Exception ex)
            {
                app.Logger.LogError(ex, "Ocorreu uma exceção ao inicializar a API: {Message}", ex.Message);
                throw;
            }
        }

        private static async Task MigratePostgreSqlDbContext(this WebApplication app, PostgreSqlDbContext context)
        {
            var dbName = context.Database.GetDbConnection().Database;

            app.Logger.LogInformation("----- {DbName}: {DbConnection}", dbName, context.Database.GetConnectionString());
            app.Logger.LogInformation("----- {DbName}: Criando o banco de dados...", dbName);

            await context.Database.EnsureCreatedAsync();
        }

        private static async Task MigrateMongoDbContextAsync(this WebApplication app, MongoDbContext mongoDbContext)
        {
            app.Logger.LogInformation("----- MongoDB: {Connection}", mongoDbContext.GetConnectionString());
            app.Logger.LogInformation("----- MongoDB: Collections estão sendo criadas...");
            await mongoDbContext.MigrateDatabase();
            app.Logger.LogInformation("----- MongoDB: Collections criadas com sucesso!");
        }
    }
}
