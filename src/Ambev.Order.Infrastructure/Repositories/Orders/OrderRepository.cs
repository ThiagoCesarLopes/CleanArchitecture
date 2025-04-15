

using CleanArchitecture.OrderManagement.Domain.Orders;
using CleanArchitecture.OrderManagement.Domain.Orders.Interfaces;
using CleanArchitecture.OrderManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.OrderManagement.Infrastructure.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order pedido)
        {
            _context.Order.Add(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistOrderAsync(int pedidoId)
        {
            return await _context.Order.AnyAsync(p => p.PedidoId == pedidoId);
        }

        public async Task<Order?> GetOrderIdAsync(int id)
        {
            return await _context.Order.Include(p => p.Itens).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Order>> ListOrderStatusAsync(string status)
        {
            return await _context.Order.Include(p => p.Itens)
                                         .Where(p => p.Status == status)
                                         .ToListAsync();
        }
    }

}
