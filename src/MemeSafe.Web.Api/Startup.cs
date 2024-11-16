using MemeSafe.AspNetCore.Extensions;
using MemeSafe.AutoMapper;
using MemeSafe.Data.Infrastructure;
using MemeSafe.Services.AspNetCore;

namespace MemeSafe.Web.Api;

public class Startup(IConfiguration configuration)
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services
            .AddMemeSafeAutoMapperConfiguration()
            .AddMemeSafeServices()
            .AddMemeSafeAuthentication(configuration)
            .AddMemeSafeSwaggerConfiguration()
            .AddMemeSafeLoggingService(configuration);

        services.AddDbContext<DataContext>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI(config =>
        {
            config.DocumentTitle = "Meme Safe API";
        });

        app.UseMemeSafeAuthentication();

        app.UseRouting();
        app.UseEndpoints(x => x.MapControllers());
    }
}
