using CleanArchitecture.OrderManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.OrderManagement.Api.Extesions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
