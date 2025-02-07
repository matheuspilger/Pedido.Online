using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pedido.Online.Domain.Core.Bases;
using Pedido.Online.Domain.Core.Bases.Interfaces;
using Pedido.Online.Domain.Entities.CustomerAggregate;
using Pedido.Online.Domain.Entities.OrderAggregate;
using Pedido.Online.Domain.Entities.ProductAggregate;
using Pedido.Online.Infrastructure.Extensions;
using Pedido.Online.Infrastructure.Mappings.PostgreSql;

namespace Pedido.Online.Infrastructure.Contexts
{
    public class PostgreSqlDbContext(IMediator mediator, DbContextOptions<PostgreSqlDbContext> options) : DbContext(options), IUnitOfWork
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderItemMap());
            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            await mediator.PublishEvent(this).ConfigureAwait(false);
            var success = await SaveChangesAsync() > 0;
            return success;
        }
    }
}
