namespace MemeSafe.Data.Entity;

/// <summary>
/// Изображение
/// </summary>
public class Image
{
    /// <inheritdoc cref="ImageInfo"/>
    public ImageInfo? Info { get; set; }

    /// <summary>
    /// Изображение в Base64
    /// </summary>
    public string Base64String { get; set; } = null!;
}
