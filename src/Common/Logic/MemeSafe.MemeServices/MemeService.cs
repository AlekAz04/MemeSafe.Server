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

    /// <summary>
    /// Получить мем по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены запроса</param>
    /// <returns>Мем в <see cref="MemeShowDto"/></returns>
    public async Task<MemeShowDto> GetMemeById(Guid id, CancellationToken cancellationToken)
    {
        var meme = await _context.Set<Meme>()
            .Where(x => x.Id == id)
            .FirstAsync(cancellationToken);

        return _mapper.Map<MemeShowDto>(meme);
    }

    /// <summary>
    /// Добавить мем
    /// </summary>
    /// <param name="createDto">ДТО создания объекта меме</param>
    /// <param name="cancellationToken"></param>
    public async Task AddMeme(MemeCreateDto createDto, CancellationToken cancellationToken)
    {
        var addMeme = _mapper.Map<Meme>(createDto);

        var meme = await _context
            .Set<Meme>()
            .AddAsync(addMeme, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
