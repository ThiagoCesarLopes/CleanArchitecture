namespace CleanArchitecture.OrderManagement.Api.Extensions
{
    using CleanArchitecture.OrderManagement.Domain.Orders.Interfaces;
    using CleanArchitecture.OrderManagement.Infrastructure.FeatureManager;
    using CleanArchitecture.OrderManagement.Infrastructure.FeatureManager.Interfaces;
    using CleanArchitecture.OrderManagement.Infrastructure.Repositories.Orders;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IFeatureManager, FeatureManager>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            return services;
        }
    }
}
