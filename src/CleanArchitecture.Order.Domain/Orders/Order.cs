using CleanArchitecture.OrderManagement.Domain.Orders.Enum;

namespace CleanArchitecture.OrderManagement.Domain.Orders
{
    public class Order
    {
        public Guid OrderId { get; private set; }
        public Guid ClientId { get; private set; }
        public List<OrderItem> Items { get; private set; } = new();
        public decimal Tax { get; private set; }
        public Status Status { get; private set; } 
        public Order(Guid orderId, Guid clientId, decimal tax, Status status)
        {
            OrderId = orderId;
            ClientId = clientId;
            Tax = tax;
            Status = status;
        }

        public void AddItem(Guid orderId ,Guid productId, int amount, decimal value)
        {
            Items.Add(new OrderItem(orderId, productId, amount, value));
        }

        public void CalcularImposto(bool newRule)
        {
            var total = Items.Sum(i => i.Amount * i.Value);
            Tax = total * (newRule ? 0.2m : 0.3m);
        }
    }
}
