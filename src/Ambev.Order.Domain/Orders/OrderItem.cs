namespace CleanArchitecture.OrderManagement.Domain.Orders
{
        public class OrderItem
    {
        public int ItemId { get; private set; }
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Amount { get; private set; }
        public decimal Value { get; private set; }

        public OrderItem(Guid orderId, Guid productId, int amount, decimal value)
        {
            OrderId = orderId;
            ProductId = productId;
            Amount = amount;
            Value = value;

        }
    }
}
