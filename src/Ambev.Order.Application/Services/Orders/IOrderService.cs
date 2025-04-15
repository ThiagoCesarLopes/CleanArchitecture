using CleanArchitecture.OrderManagement.Application.DTOs.Orders;

namespace CleanArchitecture.OrderManagement.Application.Services.Orders
{
    public interface IOrderService
    {
        Task<OrderResponse> CreateOrderAsync(CreateOrderRequest request);
        Task<OrderResponse?>GetOrderIdAsync(int id);
        Task<IEnumerable<OrderResponse>> ListOrderStatusAsync(string status);
    }
}
