using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pedido.Online.Domain.Entities.OrderAggregate;

namespace Pedido.Online.Infrastructure.Mappings.PostgreSql
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(c => c.Id);
            builder.Property(c => c.ProductId);
            builder.Property(c => c.ProductName).HasMaxLength(150);
            builder.Property(c => c.Quantity).HasPrecision(15, 4);
            builder.Property(c => c.UnitPrice).HasPrecision(15, 4);
            builder.Property(c => c.TotalPrice).HasPrecision(15, 4);
        }
    }
}
