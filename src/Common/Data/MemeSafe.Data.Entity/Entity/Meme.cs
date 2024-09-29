namespace MemeSafe.Data.Entity;

/// <summary>
/// Объект Мем
/// </summary>
public class Meme
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// Полный путь к файлу
    /// </summary>
    public string? FileFullPath { get; set; }

    /// <summary>
    /// Идентификатор автора
    /// </summary>
    public Guid AuthorId { get; set; } = Guid.Empty;

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTimeOffset CreatedDate { get; set; }

    /// <summary>
    /// Дата обновления
    /// </summary>
    public DateTimeOffset ModifiedDate { get; set; }
}
