using CleanArchitecture.OrderManagement.Domain.Clients.Interfaces;
using CleanArchitecture.OrderManagement.Domain.Orders.Interfaces;
using CleanArchitecture.OrderManagement.Infrastructure.Data;
using CleanArchitecture.OrderManagement.Infrastructure.FeatureManagers;
using CleanArchitecture.OrderManagement.Infrastructure.FeatureManagers.Interfaces;
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
        {
            services.AddSingleton<IFeatureManager, FeatureManager>(); 

            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IClientRepository, ClientRepository>();

            var defaultConnection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(defaultConnection).UseSnakeCaseNamingConvention());

            return services;
        }
    }

}
