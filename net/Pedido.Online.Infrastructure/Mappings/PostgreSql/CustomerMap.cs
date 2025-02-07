using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedido.Online.Domain.Entities.CustomerAggregate;

namespace Pedido.Online.Infrastructure.Mappings.PostgreSql
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.Id);
            builder.Property(c => c.IsActive);
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.Email).HasMaxLength(100);
            builder.Property(c => c.Phone).HasMaxLength(25);
        }
    }
}
