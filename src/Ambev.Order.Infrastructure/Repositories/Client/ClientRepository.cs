

using CleanArchitecture.OrderManagement.Domain.Clients;
using CleanArchitecture.OrderManagement.Domain.Clients.Interfaces;

namespace CleanArchitecture.OrderManagement.Infrastructure.Repositories.Clients
{
    public class ClientRepository : IClientRepository
    {
        private static readonly List<Client> _clients = new()
                {
                    new Client(1, Guid.NewGuid(), "Cliente Teste"),
                    new Client(2, Guid.NewGuid(), "Outro Cliente")
                };

        public Task<Client?> GetClientByIdAsync(Guid ClientId)
        {
            return Task.FromResult(_clients.FirstOrDefault(c => c.ClientId == ClientId));
        }
    }
}
