using Microsoft.Extensions.DependencyInjection;

namespace MemeSafe.AutoMapper;

/// <summary>
/// Класс расширений для <see cref="IServiceCollection"/> для добавления автомаппера
/// </summary>
public static class ServiceCollectionAutoMapperExtensions
{
    /// <summary>
    /// Добавить конфигурации автомаппера
    /// </summary>
    public static IServiceCollection AddMemeSafeAutoMapperConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapperEntityProfile));

        return services;
    }
}
