using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pedido.Online.Domain.Entities.OrderAggregate;
using Pedido.Online.Domain.Entities.CustomerAggregate;

namespace Pedido.Online.Infrastructure.Mappings.PostgreSql
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(c => c.Id);
            builder.Property(c => c.IsActive);
            builder.Property(c => c.OrderDate);
            builder.Property(c => c.Status);
            builder.Property(c => c.TotalAmount).HasPrecision(15, 4);

            builder.HasOne<Customer>()
                .WithOne()
                .HasForeignKey<Order>(x => x.CustomerId);

            builder.HasMany(x => x.Itens)
                .WithOne()
                .HasForeignKey(x => x.OrderId);
        }
    }
}
