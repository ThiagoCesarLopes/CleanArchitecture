
using CleanArchitecture.OrderManagement.Application.DTOs.Clients;
using CleanArchitecture.OrderManagement.Domain.Clients;

namespace CleanArchitecture.OrderManagement.Application.DTOs.Orders
{

    public class CreateOrderRequest
    {
        public int OrderId { get; set; }
        public Guid ClienteId { get; set; }
        public List<Guid> ProdutosIds { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }

        public CreateOrderRequest()
        {
            ProdutosIds = new List<Guid>();
        }

        public bool Validar()
        {
            if (ClienteId == Guid.Empty)
                return false;

            if (ProdutosIds == null || !ProdutosIds.Any())
                return false;

            if (ValorTotal <= 0)
                return false;

            return true;
        }
    }

}
