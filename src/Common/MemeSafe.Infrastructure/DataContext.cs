using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MemeSafe.Infrastructure;

/// <summary>
/// Контекст к базе
/// </summary>
public class DataContext(IConfigurationSection configuration) : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(configuration.GetConnectionString(nameof(DataContext)));
    }
}
