namespace MemeSafe.Data.Entity;

/// <summary>
/// ДТО возвращаемое с сервера
/// </summary>
public class MemeShowDto
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
    /// Идентификатор автора
    /// </summary>
    public Guid AuthorId { get; set; } = Guid.Empty;

    /// <summary>
    /// Картинка
    /// </summary>
    public Image Image { get; set; } = null!;

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTimeOffset CreatedDate { get; set; }

    /// <summary>
    /// Дата обновления
    /// </summary>
    public DateTimeOffset ModifiedDate { get; set; }
}
