using CleanArchitecture.OrderManagement.Domain.Orders;
using CleanArchitecture.OrderManagement.Domain.Orders.Enum;
using CleanArchitecture.OrderManagement.Domain.Orders.Interfaces;
using CleanArchitecture.OrderManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.OrderManagement.Infrastructure.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order pedido)
        {
            _context.Order.Add(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistOrderAsync(Guid orderId)
        {
            return await _context.Order.AnyAsync(p => p.OrderId == orderId);
        }

        public async Task<Order?> GetOrderByIdAsync(Guid orderId)
        {
            return await _context.Order.Include(p => p.Items).FirstOrDefaultAsync(p => p.OrderId == orderId);
        }

        public async Task<IEnumerable<Order>> ListOrderByStatusAsync(Status status)
        {
            return await _context.Order.Include(p => p.Items)
                                            .Where(p => p.Status == status)
                                            .ToListAsync();
        }
    }

}
