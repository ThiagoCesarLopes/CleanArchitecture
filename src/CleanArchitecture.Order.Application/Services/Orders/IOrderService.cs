using CleanArchitecture.OrderManagement.Application.DTOs.Orders.Request;
using CleanArchitecture.OrderManagement.Application.DTOs.Orders.Response;
using CleanArchitecture.OrderManagement.Domain.Orders.Enum;

namespace CleanArchitecture.OrderManagement.Application.Services.Orders
{
    public interface IOrderService
    {
        Task<OrderResponse> CreateOrderAsync(CreateOrderRequest request);
        Task<OrderResponse?>GetOrderByIdAsync(Guid Orderid);
        Task<IEnumerable<OrderResponse>> ListOrderByStatusAsync(Status status);
    }
}
