using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pedido.Online.Domain.Entities.ProductAggregate;

namespace Pedido.Online.Infrastructure.Mappings.PostgreSql
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(c => c.Id);
            builder.Property(c => c.IsActive);
            builder.Property(c => c.Name).HasMaxLength(150);
            builder.Property(c => c.Price).HasPrecision(15, 4);
        }
    }
}
