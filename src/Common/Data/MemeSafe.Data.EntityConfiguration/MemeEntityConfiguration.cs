using MemeSafe.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace MemeSafe.Data.EntityConfiguration;

/// <summary>
/// Конфигурация сущности <see cref="Meme"/>
/// </summary>
public class MemeEntityConfiguration : IEntityTypeConfiguration<Meme>
{
    public void Configure(EntityTypeBuilder<Meme> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.ImageInfo)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<ImageInfo>(v)!
                );
    }
}
