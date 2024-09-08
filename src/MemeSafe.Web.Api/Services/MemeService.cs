 using AutoMapper;
 using MemeSafe.Data.Entity;
 using Microsoft.EntityFrameworkCore;

 namespace MemeSafe.Web.Api;

public class MemeService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public MemeService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<MemeShowDTO> GetMemeById(Guid id, CancellationToken cancellationToken)
    {
        var meme = await _context.Set<Meme>()
            .Where(x => x.Id == id)
            .FirstAsync(cancellationToken);

        return _mapper.Map<MemeShowDTO>(meme);
    }

    public async Task<MemeShowDTO> AddMeme(MemeCreateDto createDto, CancellationToken cancellationToken)
    {
        var addMeme = _mapper.Map<Meme>(createDto);

        var meme = await _context
            .Set<Meme>()
            .AddAsync(addMeme, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<MemeShowDTO>(meme);
    }
}
