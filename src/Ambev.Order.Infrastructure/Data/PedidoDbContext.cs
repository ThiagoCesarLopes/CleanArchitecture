

using CleanArchitecture.OrderManagement.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.OrderManagement.Infrastructure.Data
{
    public class PedidoDbContext : DbContext
    {
        public PedidoDbContext(DbContextOptions<PedidoDbContext> options) : base(options)
        {
        }

        // DbSet para a entidade Pedido
        public DbSet<Domain.Orders.Order> Pedidos { get; set; }

        // Configuração do modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da entidade Pedido
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Status).IsRequired().HasMaxLength(50);
                entity.HasMany(p => p.Itens)
                      .WithOne()
                      .HasForeignKey("PedidoId")
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuração da entidade ItemPedido
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(i => new { i.ProdutoId });
                entity.Property(i => i.Quantidade).IsRequired();
                entity.Property(i => i.Valor).IsRequired().HasColumnType("decimal(18,2)");
            });
        }
    }
}
