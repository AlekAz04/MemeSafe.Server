namespace MemeSafe.Data.Entity;

/// <summary>
/// ДТО создания объекта "мем"
/// </summary>
public class MemeCreateDto
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; } = null!;
}
