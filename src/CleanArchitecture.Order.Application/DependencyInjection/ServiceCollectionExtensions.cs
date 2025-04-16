namespace CleanArchitecture.OrderManagement.Application.DependencyInjection;

using CleanArchitecture.OrderManagement.Application.Services.Clients;
using CleanArchitecture.OrderManagement.Application.Services.Orders;
using CleanArchitecture.OrOrderManagementder.Application.Services.Clients;
using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IClientService, ClientService>();
        return services;
        }
    }

