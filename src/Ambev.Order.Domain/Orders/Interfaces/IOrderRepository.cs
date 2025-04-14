

using CleanArchitecture.OrderManagement.Domain.Orders;

namespace CleanArchitecture.OrderManagement.Domain.Orders.Interfaces
{
    public interface IOrderRepository
    {
        Task AdicionarAsync(Order order);
        Task<bool> ExistePedidoAsync(int orderId);
        Task<Order?> ObterPorIdAsync(int id);
        Task<IEnumerable<Order>> ListarPorStatusAsync(string status);
    }
}
