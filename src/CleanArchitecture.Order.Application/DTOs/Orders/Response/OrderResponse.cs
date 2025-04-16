using CleanArchitecture.OrderManagement.Application.DTOs.Clients.Response;
using CleanArchitecture.OrderManagement.Domain.Orders.Enum;

namespace CleanArchitecture.OrderManagement.Application.DTOs.Orders.Response
{

    public class OrderResponse
    {
        public OrderResponse(Guid orderId, Guid clientId, decimal tax, Status status, List<OrderItemsResponse> items)
        {
            OrderId = orderId;
            ClientId = clientId;
            Tax = tax;
            Status = status;
            Items = items;
        }

        public Guid OrderId { get; set; }
        public Guid ClientId { get; set; }
        public decimal Tax { get; set; }
        public Status Status { get; set; } 
        public List<OrderItemsResponse> Items { get; set; } = new();


    }

}
