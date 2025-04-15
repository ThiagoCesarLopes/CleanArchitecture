

namespace CleanArchitecture.OrderManagement.Domain.Clients
{
    public class Client
    {
        public int Id { get; private set; }
        public Guid ClientId { get; private set; }
        public string Name { get; private set; }

        public Client(int id,Guid clientId, string name)
        {
            Id = id;
            ClientId = clientId;
            Name = name;
        }
    }
}
