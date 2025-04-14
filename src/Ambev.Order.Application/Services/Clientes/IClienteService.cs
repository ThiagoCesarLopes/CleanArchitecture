using CleanArchitecture.OrderManagement.Domain.Clientes;

namespace CleanArchitecture.OrderManagement.Application.Services.Clientes
{
    public interface IClienteService
    {
        Task<Cliente?> ObterPorIdAsync(int id);
    }
}
