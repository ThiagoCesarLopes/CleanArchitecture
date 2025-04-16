using CleanArchitecture.OrderManagement.Domain.Clients;

namespace CleanArchitecture.OrderManagement.Application.DTOs.Clients.Response
{
    public class ClientResponse
    {
        public Guid ClientId { get; private set; }
        public string Name { get; private set; }
    }
}
