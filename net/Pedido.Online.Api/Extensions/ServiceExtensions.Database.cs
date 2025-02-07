using Microsoft.EntityFrameworkCore;
using Pedido.Online.Domain.Core.Configuration;
using Pedido.Online.Infrastructure.Contexts;

namespace Pedido.Online.Api.Extensions
{
    public static partial class ServiceExtensions
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            var database = configuration.GetSection(
                DatabaseConfiguration.ConfigSectionPath).Get<DatabaseConfiguration>()
                    ?? throw new ArgumentNullException(nameof(DatabaseConfiguration));

            services.AddDbContext<PostgreSqlDbContext>(options =>
                options.UseNpgsql(database.SqlConnection));

            services.AddSingleton(MongoDbContext.Initialize(database.NoSqlConnection, database.NoSqlDatabase));

            return services;
        }
    }
}
