using MemeSafe.AutoMapper;
using MemeSafe.Data.Infrastructure;
using MemeSafe.Services.AspNetCore;
using Serilog;


namespace MemeSafe.Web.Api;

public class Startup(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services.AddMemeSafeAutoMapperConfiguration()
            .AddMemeSafeServices();

        services.AddDbContext<DataContext>();

        var log = Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(_configuration)
            .WriteTo.Console()
            .CreateLogger();

        services.AddSerilog(log);

        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseRouting();
        app.UseEndpoints(x => x.MapControllers());
    }
}
