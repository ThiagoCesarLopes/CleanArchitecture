
using CleanArchitecture.OrderManagement.Application.DTOs.Clientes;
using CleanArchitecture.OrderManagement.Domain.Clientes;
using CleanArchitecture.OrderManagement.Domain.Orders;

namespace CleanArchitecture.OrderManagement.Application.DTOs.Orders
{

    public class OrderResponse
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Guid ClienteId { get; set; }
        public ClienteResponse? Cliente { get; set; }
        public decimal Imposto { get; set; }
        public string Status { get; set; } = string.Empty;
        public List<ItemPedidoResponse> Itens { get; set; } = new();

        public OrderResponse(Order order, Cliente? cliente = null)
        {
            Id = order.Id;
            PedidoId = order.PedidoId;
            ClienteId = order.ClienteId;
            Imposto = order.Imposto;
            Status = order.Status;
            Itens = order.Itens.Select(i => new ItemPedidoResponse
            {
                ProdutoId = i.ProdutoId,
                Quantidade = i.Quantidade,
                Valor = i.Valor
            }).ToList();

            if (cliente != null)
            {
                Cliente = new ClienteResponse(cliente);
            }
        }
    }

}
