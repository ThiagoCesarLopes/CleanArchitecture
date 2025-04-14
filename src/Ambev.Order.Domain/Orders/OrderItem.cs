namespace CleanArchitecture.OrderManagement.Domain.Orders
{
        public class OrderItem

    {
        public int ProdutoId { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Valor { get; private set; }

        public OrderItem(int produtoId, int quantidade, decimal valor)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade;
            Valor = valor;
        }
    }
}
