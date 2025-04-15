using CleanArchitecture.OrderManagement.Domain.Clients.Interfaces;
using CleanArchitecture.OrderManagement.Domain.Orders.Interfaces;
using CleanArchitecture.OrderManagement.Infrastructure.Data;
using CleanArchitecture.OrderManagement.Infrastructure.Repositories.Clients;
using CleanArchitecture.OrderManagement.Infrastructure.Repositories.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CleanArchitecture.OrderManagement.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {      // Ensure ClienteRepository implements IClienteRepository
            services.AddScoped<IOrderRepository, OrderRepository>();

            // Ensure ClienteRepository implements IClienteRepository
            services.AddScoped<IClientRepository, ClientRepository>();

            // Fix for CS0103: Define DefaultConnection using configuration
            var defaultConnection = configuration.GetConnectionString("DefaultConnection");

            // Ensure Microsoft.EntityFrameworkCore and Npgsql.EntityFrameworkCore.PostgreSQL are installed
            services.AddDbContext<OrderDbContext>(options =>
                options.UseNpgsql(defaultConnection).UseSnakeCaseNamingConvention());
            
            return services;
        }
    }

}
