using MemeSafe.Common;
using MemeSafe.Data.Entity;

namespace MemeSafe.Extensions;

public static class ImageExtensions
{
    /// <summary>
    /// Сохранить изображение из base64
    /// </summary>
    /// <param name="image">Изображение в <see cref="Image"/></param>
    /// <param name="token">Токен отмены запроса</param>
    public static async Task<Image> SaveImage(this Image image, CancellationToken token)
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "Memes");

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        if (image.Info is null)
        {
            throw new CommonErrorException($"{nameof(image.Info)} is null");
        }

        string imageFullName = $"{image.Info.FileName}_{Guid.NewGuid()}.{image.Info.FileExtention}";

        image.Info.Path = Path.Combine(path, imageFullName);

        byte[] imageBytes = Convert.FromBase64String(image.Base64String);

        await File.WriteAllBytesAsync(image.Info.Path, imageBytes, token);
        return image;
    }

    /// <summary>
    /// Получить Base64 строку из файла
    /// </summary>
    /// <param name="imageInfo">Информация об изображении</param>
    public static async Task<Image> GetBase64Image(this ImageInfo imageInfo)
    {
        byte[] imageBytes = await File.ReadAllBytesAsync(imageInfo.Path ?? throw new InvalidOperationException());

        string base64String = Convert.ToBase64String(imageBytes);

        return new Image()
        {
            Base64String = base64String,
            Info = imageInfo
        };
    }
}
