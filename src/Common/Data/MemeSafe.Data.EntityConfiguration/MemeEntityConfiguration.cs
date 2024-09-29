using MemeSafe.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemeSafe.Data.EntityConfiguration;

/// <summary>
/// Конфигурация сущности <see cref="Meme"/>
/// </summary>
public class MemeEntityConfiguration : IEntityTypeConfiguration<Meme>
{
    public void Configure(EntityTypeBuilder<Meme> builder)
    {
        builder.HasKey(m => m.Id);
    }
}
