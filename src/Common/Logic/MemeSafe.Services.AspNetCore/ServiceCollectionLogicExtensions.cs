using MemeSafe.MemeServices;
using Microsoft.Extensions.DependencyInjection;

namespace MemeSafe.Services.AspNetCore;

/// <summary>
/// Класс расширений для <see cref="IServiceCollection"/> для добавления сервисов
/// </summary>
public static class ServiceCollectionLogicExtensions
{
    /// <summary>
    /// Добавить сервисы логики программы
    /// </summary>
    public static IServiceCollection AddMemeSafeServices(this IServiceCollection servics)
    {
        servics.AddScoped<MemeService>();

        return servics;
    }
}
