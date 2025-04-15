

using CleanArchitecture.OrderManagement.Domain.Orders;

namespace CleanArchitecture.OrderManagement.Domain.Orders.Interfaces
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Task<bool> ExistOrderAsync(int orderId);
        Task<Order?> GetOrderIdAsync(int id);
        Task<IEnumerable<Order>> ListOrderStatusAsync(string status);
    }
}
