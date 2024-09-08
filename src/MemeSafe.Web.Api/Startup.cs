using Serilog;


namespace MemeSafe.Web.Api;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services.AddAutoMapper(typeof(AutoMapperEntityProfile));


        services.AddDbContext<DataContext>();

        var log = Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(_configuration)
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .CreateLogger();

        services.AddSerilog(log);

        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseEndpoints(x => x.MapControllers());
    }
}
