using CleanArchitecture.OrderManagement.Domain.Clientes;

namespace CleanArchitecture.OrderManagement.Application.Services.Clientes
{
    public interface IClienteService
    {
        Task<Cliente?> GetClientByIdAsync(Guid clientId);
    }
}
