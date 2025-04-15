using CleanArchitecture.OrderManagement.Domain.Clients;

namespace CleanArchitecture.OrderManagement.Application.Services.Clients
{
    public interface IClientService
    {
        Task<Client?> GetClientByIdAsync(Guid clientId);
    }
}
