

using CleanArchitecture.OrderManagement.Domain.Clientes;
using CleanArchitecture.OrderManagement.Domain.Clientes.Interfaces;

namespace CleanArchitecture.OrderManagement.Infrastructure.Repositories.Clientes
{
    public class ClienteRepository : IClienteRepository
    {
        private static readonly List<Cliente> _clientes = new()
                {
                    new Cliente(1, Guid.NewGuid(), "Cliente Teste"),
                    new Cliente(2, Guid.NewGuid(), "Outro Cliente")
                };

        public Task<Cliente?> GetClientByIdAsync(Guid ClientId)
        {
            return Task.FromResult(_clientes.FirstOrDefault(c => c.ClientId == ClientId));
        }
    }
}
