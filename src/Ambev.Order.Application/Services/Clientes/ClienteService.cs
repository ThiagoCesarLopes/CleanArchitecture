
using CleanArchitecture.OrderManagement.Application.Services.Clientes;
using CleanArchitecture.OrderManagement.Domain.Clientes;
using CleanArchitecture.OrderManagement.Domain.Clientes.Interfaces;

namespace CleanArchitecture.OrOrderManagementder.Application.Services.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente?> ObterPorIdAsync(int id)
        {
            return await _clienteRepository.ObterPorIdAsync(id);
        }
    }
}
