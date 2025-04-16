


using CleanArchitecture.OrderManagement.Application.DTOs.Orders;
using CleanArchitecture.OrderManagement.Application.DTOs.Orders.Request;
using CleanArchitecture.OrderManagement.Application.DTOs.Orders.Response;
using CleanArchitecture.OrderManagement.Domain.Orders.Enum;

namespace CleanArchitecture.OrderManagement.Domain.Orders.Interfaces
{
    public interface IOrderService
    {
        Task<OrderResponse> CreateOrderAsync(CreateOrderRequest request);
        Task<OrderResponse?> GetOrderByIdAsync(Guid orderId);
        Task<IEnumerable<OrderResponse>> ListOrderByStatusAsync(Status status);
    }
}
