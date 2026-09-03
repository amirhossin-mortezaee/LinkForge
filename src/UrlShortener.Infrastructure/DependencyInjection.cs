using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Domain.Interfaces;
using UrlShortener.Infrastructure.Services;

namespace UrlShortener.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IShortCodeGenerator, ShortCodeGenerator>();

        // فردا سرویس‌های دیگه (DbContext, Repositories, ...) هم اینجا اضافه می‌شن
        return services;
    }
}
