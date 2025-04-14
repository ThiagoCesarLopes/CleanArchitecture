

using CleanArchitecture.OrderManagement.Domain.Clientes;
using CleanArchitecture.OrderManagement.Domain.Clientes.Interfaces;

namespace CleanArchitecture.OrderManagement.Infrastructure.Repositories.Clientes
{
    public class ClienteRepository : IClienteRepository
    {
        private static readonly List<Cliente> _clientes = new()
            {
                new Cliente(1, "Cliente Teste"),
                new Cliente(2, "Outro Cliente")
            };

        public Task<Cliente?> ObterPorIdAsync(int id)
        {
            return Task.FromResult(_clientes.FirstOrDefault(c => c.Id == id));
        }
    }
}
