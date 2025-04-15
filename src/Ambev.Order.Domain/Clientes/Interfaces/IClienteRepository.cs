
using CleanArchitecture.OrderManagement.Domain.Clientes;

namespace CleanArchitecture.OrderManagement.Domain.Clientes.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente?> GetClientByIdAsync(Guid ClientId);
    }
}
