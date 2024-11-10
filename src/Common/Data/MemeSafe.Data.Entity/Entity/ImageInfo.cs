namespace MemeSafe.Data.Entity;

/// <summary>
/// Информация о файле
/// </summary>
public class ImageInfo
{
    /// <summary>
    /// Название фалйа
    /// </summary>
    public string FileName { get; set; } = null!;

    /// <summary>
    /// Расширение файла
    /// </summary>
    public string FileExtention { get; set; } = null!;

    /// <summary>
    /// Полный путь к файлу на сервере
    /// </summary>
    public string? Path { get; set; }
}
