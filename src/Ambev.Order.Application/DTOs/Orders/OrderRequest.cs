using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.OrderManagement.Application.DTOs.Orders
{
    public class OrderRequest
    {
        public Guid ClienteId { get; set; }
        public List<Guid> ProdutosIds { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }

        public bool Validar()
        {
            return ClienteId != Guid.Empty &&
                   ProdutosIds != null && ProdutosIds.Any() &&
                   DataPedido != default &&
                   ValorTotal > 0;
        }
    }
}
