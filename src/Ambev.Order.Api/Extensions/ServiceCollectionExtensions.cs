namespace CleanArchitecture.OrderManagement.Api.Extensions
{
    using CleanArchitecture.OrderManagement.Application.Services.Orders;
    using CleanArchitecture.OrderManagement.Domain.Orders.Interfaces;
    using CleanArchitecture.OrderManagement.Infrastructure.FeatureManager.Interfaces;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddSingleton<IFeatureManager, FeatureManager>();
            services.AddScoped<IOrderRepository, PedidoRepository>();
            return services;
        }
    }
}
