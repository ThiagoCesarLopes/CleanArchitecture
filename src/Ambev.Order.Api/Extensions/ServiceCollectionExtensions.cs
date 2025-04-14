namespace CleanArchitecture.OrderManagement.Api.Extensions
{
    using CleanArchitecture.OrderManagement.Domain.Orders.Interfaces;
    using Microsoft.Extensions.DependencyInjection;

    namespace API.Extensions;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, PedidoRepository>();
            return services;
        }
    }
}
