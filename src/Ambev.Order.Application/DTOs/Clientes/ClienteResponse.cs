


using CleanArchitecture.OrderManagement.Domain.Clientes;

namespace CleanArchitecture.OrderManagement.Application.DTOs.Clientes
{
    public class ClienteResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public ClienteResponse(Cliente cliente)
        {
            Id = cliente.Id;
            Nome = cliente.Nome;
        }
    }
}
