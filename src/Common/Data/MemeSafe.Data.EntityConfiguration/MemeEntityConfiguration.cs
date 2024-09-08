using MemeSafe.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemeSafe.Data.Entity.EntityConfiguration;

public class MemeEntityConfiguration : IEntityTypeConfiguration<Meme>
{
    public void Configure(EntityTypeBuilder<Meme> builder)
    {
        builder.HasKey(m => m.Id);
    }
}
