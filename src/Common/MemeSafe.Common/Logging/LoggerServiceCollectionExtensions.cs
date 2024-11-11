using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace MemeSafe.AspNetCore.Extensions;

public static class LoggerServiceCollectionExtensions
{
    public static IServiceCollection AddMemeSafeLoggingService(this IServiceCollection services, IConfiguration configuration)
    {
        var log = Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .WriteTo.Console()
            .CreateLogger();

        services.AddSerilog(log);
        return services;
    }
}
