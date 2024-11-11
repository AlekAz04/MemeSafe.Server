using AutoMapper;
using MemeSafe.Data.Entity;
using MemeSafe.Data.Infrastructure;
using MemeSafe.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MemeSafe.MemeServices;

/// <summary>
/// Сервис сущности <see cref="Meme"/>
/// </summary>
public class MemeService(DataContext context, IMapper mapper)
{
    /// <inheritdoc cref="DataContext"/>
    private readonly DataContext _context = context;

    /// <inheritdoc cref="IMapper"/>
    private readonly IMapper _mapper = mapper;

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

        memeShow.Image = await meme.ImageInfo.GetBase64Image();

        return memeShow;
    }

    /// <summary>
    /// Добавить мем
    /// </summary>
    /// <param name="createDto">ДТО создания объекта меме</param>
    /// <param name="cancellationToken">Токен отмены запроса</param>
    public async Task AddMeme(MemeCreateDto createDto, CancellationToken cancellationToken)
    {
        await createDto.Image.SaveImage(cancellationToken);

        var addMeme = _mapper.Map<Meme>(createDto);

        await _context.Set<Meme>()
            .AddAsync(addMeme, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
