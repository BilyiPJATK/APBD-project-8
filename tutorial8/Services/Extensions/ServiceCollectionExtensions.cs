using Microsoft.Extensions.DependencyInjection;
using tutorial8.Services;
using tutorial8.Services.Abstractions;

namespace tutorial8.Services.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IWarehouseService, WarehouseService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IProductWarehouseService, ProductWarehouseService>();
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}