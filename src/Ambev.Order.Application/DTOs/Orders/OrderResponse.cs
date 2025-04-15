
using CleanArchitecture.OrderManagement.Application.DTOs.Clients;
using CleanArchitecture.OrderManagement.Domain.Clients;
using CleanArchitecture.OrderManagement.Domain.Orders;

namespace CleanArchitecture.OrderManagement.Application.DTOs.Orders
{

    public class OrderResponse
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Guid ClientId { get; set; }
        public ClientResponse? Client { get; set; } 
        public decimal Imposto { get; set; }
        public string Status { get; set; } = string.Empty;
        public List<ItemPedidoResponse> Itens { get; set; } = new();

        public OrderResponse(Order order, Client? client = null)
        {
            Id = order.Id;
            PedidoId = order.PedidoId;
            ClientId = order.ClientId;
            Imposto = order.Imposto;
            Status = order.Status;
            Itens = order.Itens.Select(i => new ItemPedidoResponse
            {
                ProdutoId = i.ProdutoId,
                Quantidade = i.Quantidade,
                Valor = i.Valor
            }).ToList();

            if (client != null)
            {
                Client = new ClientResponse(client);
            }
        }
    }

}
