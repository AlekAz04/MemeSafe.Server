using MemeSafe.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MemeSafe.Data.Infrastructure;

/// <summary>
/// Контекст к базе данных
/// </summary>
public class DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : DbContext(options)
{
    /// <inheritdoc cref="IConfiguration"/>
    private readonly IConfiguration _configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString(nameof(DataContext)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfigurationAssemblyMarker).Assembly);
    }
}
