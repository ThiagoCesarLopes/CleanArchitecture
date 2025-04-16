

using CleanArchitecture.OrderManagement.Domain.Clients;
using CleanArchitecture.OrderManagement.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.OrderManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet para a entidade Pedido
        public DbSet<Order> Order { get; set; }
        public DbSet<Client> Client { get; set; }
        // Configuração do modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
          
        }
    }
}
