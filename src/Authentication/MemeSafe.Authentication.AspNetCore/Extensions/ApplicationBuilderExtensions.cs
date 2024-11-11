using Microsoft.AspNetCore.Builder;

namespace MemeSafe.AspNetCore.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseMemeSafeAuthentication(this IApplicationBuilder builder)
    {
        builder.UseAuthentication()
            .UseAuthorization();

        return builder;
    }
}
