


using CleanArchitecture.OrderManagement.Domain.Clients;

namespace CleanArchitecture.OrderManagement.Application.DTOs.Clients
{
    public class ClientResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ClientResponse(Client client)
        {
            Id = client.Id;
            Name = client.Name;
        }
    }
}
