using CleanArchitecture.OrderManagement.Application.DTOs.Orders.Request;
using CleanArchitecture.OrderManagement.Application.DTOs.Orders.Response;
using CleanArchitecture.OrderManagement.Domain.Orders.Enum;

namespace CleanArchitecture.OrderManagement.Application.Services.Orders
{
    public interface IOrderService
    {
        Task<OrderResponse> CreateOrderAsync(CreateClientRequest request);
        Task<OrderResponse?>GetOrderByIdAsync(int id);
        Task<IEnumerable<OrderResponse>> ListOrderByStatusAsync(Status status);
    }
}
