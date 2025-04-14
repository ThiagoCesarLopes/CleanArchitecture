
using CleanArchitecture.OrderManagement.Domain.Clientes;

namespace CleanArchitecture.OrderManagement.Domain.Clientes.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente?> ObterPorIdAsync(int id);
    }
}
