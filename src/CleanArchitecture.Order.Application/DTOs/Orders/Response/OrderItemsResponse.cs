namespace CleanArchitecture.OrderManagement.Application.DTOs.Orders.Response
{
    public class OrderItemsResponse
    {
        public OrderItemsResponse(Guid orderId, Guid productId, int amount, decimal value)
        {
            OrderId = orderId;
            ProductId = productId;
            Amount = amount;
            Value = value;
        }

        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
        public decimal Value { get; set; }
    }

}
