using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.OrderManagement.Domain.Clientes
{
    public class Cliente
    {
        public int Id { get; private set; }
        public Guid ClientId { get; private set; }
        public string Nome { get; private set; }

        public Cliente(int id,Guid clientId, string nome)
        {
            Id = id;
            ClientId = clientId;
            Nome = nome;
        }
    }
}
