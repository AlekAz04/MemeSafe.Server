using AutoMapper;
using MemeSafe.Data.Entity;
using MemeSafe.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MemeSafe.MemeServices;

 /// <summary>
 /// Сервис сущности <see cref="Meme"/>
 /// </summary>
public class MemeService
{
    /// <inheritdoc cref="DataContext"/>
    private readonly DataContext _context;

    /// <inheritdoc cref="IMapper"/>
    private readonly IMapper _mapper;

    public MemeService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // TODO Тестов бы....

    /// <summary>
    /// Получить мем по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены запроса</param>
    /// <exception cref="NullReferenceException"></exception>
    /// <returns>Мем в <see cref="MemeShowDto"/></returns>
    public async Task<MemeShowDto> GetMemeById(Guid id, CancellationToken cancellationToken)
    {
        var meme = await _context.Set<Meme>()
            .Where(x => x.Id == id)
            .FirstAsync(cancellationToken);

        var memeShow = _mapper.Map<MemeShowDto>(meme);

        memeShow.Image.Base64String = await GetBase64Image(meme.ImageInfo);

        return memeShow;
    }

    /// <summary>
    /// Добавить мем
    /// </summary>
    /// <param name="createDto">ДТО создания объекта меме</param>
    /// <param name="cancellationToken">Токен отмены запроса</param>
    public async Task AddMeme(MemeCreateDto createDto, CancellationToken cancellationToken)
    {
        await SaveImage(createDto.Image, cancellationToken);

        var addMeme = _mapper.Map<Meme>(createDto);

        var meme = await _context
            .Set<Meme>()
            .AddAsync(addMeme, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Сохранить изображение из base64
    /// </summary>
    /// <param name="image">Изображение в <see cref="Image"/></param>
    /// <param name="token">Токен отмены запроса</param>
    private async Task SaveImage(Image image, CancellationToken token)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "Memes" ) ;

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        string imageFullName = $"{image.Info.FileName}_{Guid.NewGuid().ToString()}.{image.Info.FileExtention}";

        image.Info.Path = Path.Combine(path, imageFullName);

        byte[] imageBytes = Convert.FromBase64String(image.Base64String);

        await File.WriteAllBytesAsync(image.Info.Path, imageBytes, token);
    }

    /// <summary>
    /// Получить Base64 строку из файла
    /// </summary>
    /// <param name="imageInfo">Информация об изображении</param>
    private async Task<string> GetBase64Image(ImageInfo imageInfo)
    {

        byte[] imageBytes = await File.ReadAllBytesAsync(imageInfo.Path ?? throw new InvalidOperationException());

        string base64String = Convert.ToBase64String(imageBytes);

        return base64String;
    }
}
