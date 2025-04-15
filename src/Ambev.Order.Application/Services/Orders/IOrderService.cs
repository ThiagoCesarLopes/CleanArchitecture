using CleanArchitecture.OrderManagement.Application.DTOs.Orders;

namespace CleanArchitecture.OrderManagement.Application.Services.Orders
{
    public interface IOrderService
    {
        Task<OrderResponse> CriarOrderAsync(CreateOrderRequest request);
        Task<OrderResponse?>GetOrderIdAsync(int id);
        Task<IEnumerable<OrderResponse>> ListOrderStatusAsync(string status);
    }
}
