using Pedido.Online.Domain.Repositories.Interfaces.Customers;
using Pedido.Online.Domain.Repositories.Interfaces.Orders;
using Pedido.Online.Domain.Repositories.Interfaces.Products;
using Pedido.Online.Infrastructure.Repositories.MongoDb.Customers;
using Pedido.Online.Infrastructure.Repositories.MongoDb.Orders;
using Pedido.Online.Infrastructure.Repositories.MongoDb.Products;
using Pedido.Online.Infrastructure.Repositories.PostgreSql;

namespace Pedido.Online.Api.Extensions
{
    public static partial class ServiceExtensions
    {
        public static IServiceCollection AddWriteRepositories(this IServiceCollection services)
            => services
                .AddScoped<ICustomerWriteRepository, CustomerWriteRepository>()
                .AddScoped<IProductWriteRepository, ProductWriteRepository>()
                .AddScoped<IOrderWriteRepository, OrderWriteRepository>();

        public static IServiceCollection AddEventRepositories(this IServiceCollection services)
            => services
                .AddScoped<ICustomerEventRepository, CustomerEventRepository>()
                .AddScoped<IProductEventRepository, ProductEventRepository>()
                .AddScoped<IOrderEventRepository, OrderEventRepository>();

        public static IServiceCollection AddReadRepositories(this IServiceCollection services)
            => services
                .AddScoped<ICustomerReadRepository, CustomerReadRepository>()
                .AddScoped<IProductReadRepository, ProductReadRepository>()
                .AddScoped<IOrderReadRepository, OrderReadRepository>();
    }
}
