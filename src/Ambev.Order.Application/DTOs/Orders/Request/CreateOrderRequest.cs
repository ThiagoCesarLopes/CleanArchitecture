
using CleanArchitecture.OrderManagement.Domain.Orders.Enum;

namespace CleanArchitecture.OrderManagement.Application.DTOs.Orders.Request
{

    public class CreateOrderRequest
    {
        public Guid OrderId { get; set; }
        public Guid ClienteId { get; set; }
        public List<CreateOrderItemRequest> Items { get; set; }
        public decimal Tax { get; set; }
        public Status Status { get; set; }
    }


    public class CreateOrderItemRequest {

        public Guid ProductId { get; set; }
        public int Amount { get; set; }
        public decimal value { get; set; }
    }
}
