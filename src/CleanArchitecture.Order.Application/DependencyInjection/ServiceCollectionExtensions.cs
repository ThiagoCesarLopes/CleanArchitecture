namespace CleanArchitecture.OrderManagement.Application.DependencyInjection;

using CleanArchitecture.OrderManagement.Application.Services.Clients;
using CleanArchitecture.OrderManagement.Application.Services.Orders;
using CleanArchitecture.OrOrderManagementder.Application.Services.Clients;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services )
        {

        services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly, includeInternalTypes: true);
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IClientService, ClientService>();

        return services;
        }

}