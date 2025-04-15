

namespace CleanArchitecture.OrderManagement.Application.DTOs.Client.Request
{

    public class CreateClientRequest
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
    }
}
