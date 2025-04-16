

using System.Runtime.CompilerServices;
using CleanArchitecture.OrderManagement.Domain.Clients;
using CleanArchitecture.OrderManagement.Domain.Clients.Interfaces;
using CleanArchitecture.OrderManagement.Domain.Orders;
using CleanArchitecture.OrderManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.OrderManagement.Infrastructure.Repositories.Clients
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

    
        public async Task AddAsync(Client client)
        {
            _context.Client.Add(client);
            await _context.SaveChangesAsync();
        } 
         public async Task<Client?> GetClientByIdAsync(Guid clientId)
        { 
            return await _context.Client.Where(p => p.ClientId == clientId).FirstOrDefaultAsync();
        }

      
    }
}
