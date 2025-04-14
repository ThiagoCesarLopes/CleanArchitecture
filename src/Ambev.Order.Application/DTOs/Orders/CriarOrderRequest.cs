
using CleanArchitecture.OrderManagement.Application.DTOs.Clientes;
using CleanArchitecture.OrderManagement.Domain.Clientes;

namespace CleanArchitecture.OrderManagement.Application.DTOs.Orders
{

    public class CriarOrderRequest
    {
        public Guid ClienteId { get; set; }
        public List<Guid> ProdutosIds { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }

        public CriarOrderRequest()
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
