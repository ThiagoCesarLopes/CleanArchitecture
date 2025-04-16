using CleanArchitecture.OrderManagement.Domain.Orders.Enum;

namespace CleanArchitecture.OrderManagement.Domain.Orders.Interfaces
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Task<bool> ExistOrderAsync(Guid orderId);
        Task<Order?> GetOrderByIdAsync(Guid orderId);
        Task<IEnumerable<Order>> ListOrderByStatusAsync(Status status);
    }
}
