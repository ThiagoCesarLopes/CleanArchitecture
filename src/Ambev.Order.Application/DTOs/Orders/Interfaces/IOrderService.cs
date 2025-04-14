


using CleanArchitecture.OrderManagement.Application.DTOs.Orders;

namespace CleanArchitecture.OrderManagement.Domain.Orders.Interfaces
{
    public interface IOrderService
    {
        Task<OrderResponse> CriarPedidoAsync(CriarOrderRequest request);
        Task<OrderResponse?> ObterPorIdAsync(int id);
        Task<IEnumerable<OrderResponse>> ListarPorStatusAsync(string status);
    }
}
