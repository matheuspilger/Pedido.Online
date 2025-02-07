namespace Pedido.Online.Api.Extensions
{
    public static partial class ServiceExtensions
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddCommandHandlers()
                .AddDbContexts(configuration)
                .AddWriteRepositories()
                .AddEventRepositories()
                .AddReadRepositories();
    }
}