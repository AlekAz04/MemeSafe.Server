using MemeSafe.Data.Entity.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace MemeSafe.Web.Api;

public class DataContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString(nameof(DataContext)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfigurationAssemblyMarker).Assembly);
    }
}
