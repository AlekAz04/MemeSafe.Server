using Microsoft.Extensions.DependencyInjection;

namespace MemeSafe.Infrastructure;

/// <summary>
/// Класс расширений для <see cref="IServiceCollection"/>
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Добавить инфраструктуру приложения
    /// </summary>
    public static IServiceCollection AddMemeSafeInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<DataContext>();
        return services;
    }
}
