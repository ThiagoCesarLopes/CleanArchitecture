
using CleanArchitecture.OrderManagement.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace CleanArchitecture.OrderManagement.Infrastructure.Configurations
{
    public sealed class OrderConfiguration: IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(o => o.OrderId);
            builder.Property(o => o.OrderId).IsRequired().ValueGeneratedNever();
            builder.Property(o => o.ClientId).IsRequired();
            builder.Property(o => o.Tax).IsRequired();
            builder.Property(o => o.Status).IsRequired().HasMaxLength(50);

            builder.HasMany(o => o.Items)
                .WithOne()
                .HasForeignKey(i => i.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
