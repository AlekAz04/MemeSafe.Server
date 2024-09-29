using AutoMapper;
using MemeSafe.Data.Entity;

namespace MemeSafe.AutoMapper;

/// <summary>
/// Профиль для автомаппера
/// </summary>
public class AutoMapperEntityProfile : Profile
{
    public AutoMapperEntityProfile()
    {
        CreateMap<Meme, MemeShowDto>().ReverseMap();

        CreateMap<MemeCreateDto, Meme>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTimeOffset.UtcNow))
            .ForMember(x => x.AuthorId, opt => opt.MapFrom(src => Guid.Empty));
    }
}
