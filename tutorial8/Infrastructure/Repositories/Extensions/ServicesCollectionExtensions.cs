using tutorial8.Infrastructure.Repositories.Abstractions;
using tutorial8.Infrastructure.Repositories;

namespace tutorial8.Infrastructure.Repositories.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IProductWarehouseRepository, ProductWarehouseRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}