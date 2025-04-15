
using CleanArchitecture.OrderManagement.Domain.Clients;

namespace CleanArchitecture.OrderManagement.Domain.Clients.Interfaces
{
    public interface IClientRepository
    {
        Task<Client?> GetClientByIdAsync(Guid ClientId);
    }
}
