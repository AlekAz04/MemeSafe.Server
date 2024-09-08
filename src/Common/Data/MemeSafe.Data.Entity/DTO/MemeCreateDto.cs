namespace MemeSafe.Data.Entity;

public class MemeCreateDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid AuthorId { get; set; } = Guid.Empty;
}
