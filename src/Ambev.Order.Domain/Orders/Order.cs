namespace CleanArchitecture.OrderManagement.Domain.Orders
{
    public class Order
    {
        public int Id { get; private set; }
        public int PedidoId { get; private set; }
        public Guid ClienteId { get; private set; }
        public List<OrderItem> Itens { get; private set; } = new();
        public decimal Imposto { get; private set; }
        public string Status { get; private set; } = "Criado";

        public Order(int pedidoId, Guid clienteId)
        {
            PedidoId = pedidoId;
            ClienteId = clienteId;
        }

        public void AdicionarItem(int produtoId, int quantidade, decimal valor)
        {
            Itens.Add(new OrderItem(produtoId, quantidade, valor));
        }

        public void CalcularImposto(bool novaRegra)
        {
            var total = Itens.Sum(i => i.Quantidade * i.Valor);
            Imposto = total * (novaRegra ? 0.2m : 0.3m);
        }
    }
}
