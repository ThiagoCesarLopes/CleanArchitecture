
using CleanArchitecture.OrderManagement.Application.Services.Clients;
using CleanArchitecture.OrderManagement.Domain.Clients;
using CleanArchitecture.OrderManagement.Domain.Clients.Interfaces;

namespace CleanArchitecture.OrOrderManagementder.Application.Services.Clients
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client?> GetClientByIdAsync(Guid clientId)
        {
            return await _clientRepository.GetClientByIdAsync(clientId);
        }
        public async Task<Client?> AddAsync(Client client)
        {
            return await _clientRepository.AddAsync(client);
        }

    }
}
