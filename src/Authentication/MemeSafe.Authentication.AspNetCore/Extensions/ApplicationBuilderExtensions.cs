using Microsoft.AspNetCore.Builder;

namespace MemeSafe.AspNetCore.Extensions;

/// <summary>
/// Класс расширений для <see cref="IApplicationBuilder"/>
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Использовать барьерную авторизацию
    /// </summary>
    public static IApplicationBuilder UseMemeSafeAuthentication(this IApplicationBuilder builder)
    {
        builder.UseAuthentication()
            .UseAuthorization();

        return builder;
    }
}
