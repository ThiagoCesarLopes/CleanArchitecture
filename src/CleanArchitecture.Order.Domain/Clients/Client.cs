

namespace CleanArchitecture.OrderManagement.Domain.Clients
{
    public class Client
    {
        public Client(string name)
        {
            ClientId = Guid.NewGuid();
            Name = name;
        }

        public Guid ClientId { get; private set; }
        public string Name { get; private set; }
    }
}
