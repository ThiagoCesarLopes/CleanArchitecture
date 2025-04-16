
using CleanArchitecture.OrderManagement.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.OrderManagement.Infrastructure.Configurations
{
    public sealed class OrderItemConfiguration: IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");
			builder.HasKey(o => new { o.ItemId, o.OrderId });
			builder.Property(o => o.OrderId).IsRequired().ValueGeneratedNever();
			builder.Property(o => o.ProductId).IsRequired();    
			builder.Property(o => o.Amount).IsRequired();
			builder.Property(o => o.Value).IsRequired();
			
		}
	}
}
