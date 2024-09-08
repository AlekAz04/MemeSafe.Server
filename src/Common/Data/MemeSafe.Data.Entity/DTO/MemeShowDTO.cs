namespace MemeSafe.Data.Entity;

public class MemeShowDTO
{
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public Guid AuthorId { get; set; } = Guid.Empty;

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset ModifiedDate { get; set; }
}
