

using CleanArchitecture.OrderManagement.Domain.Orders;
using CleanArchitecture.OrderManagement.Domain.Orders.Interfaces;
using CleanArchitecture.OrderManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.OrderManagement.Infrastructure.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PedidoDbContext _context;

        public OrderRepository(PedidoDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Order pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExisteOrdersync(int pedidoId)
        {
            return await _context.Pedidos.AnyAsync(p => p.PedidoId == pedidoId);
        }

        public async Task<Order?> ObterPorIdAsync(int id)
        {
            return await _context.Pedidos.Include(p => p.Itens).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Order>> ListarPorStatusAsync(string status)
        {
            return await _context.Pedidos.Include(p => p.Itens)
                                         .Where(p => p.Status == status)
                                         .ToListAsync();
        }
    }

}
