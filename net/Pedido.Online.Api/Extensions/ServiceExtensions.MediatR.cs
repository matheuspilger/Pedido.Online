using Pedido.Online.Domain.Core.Configuration;
using System.Reflection;

namespace Pedido.Online.Api.Extensions
{
    public static partial class ServiceExtensions
    {
        public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            var assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies()
                .Where(x => x.Name != null && x.Name.Contains(BaseConfiguration.BaseName))
                .Select(x => Assembly.Load(x.FullName)).ToArray();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));
            return services;
        }
    }
}
