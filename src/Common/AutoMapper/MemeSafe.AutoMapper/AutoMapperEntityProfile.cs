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
        CreateMap<Meme, MemeShowDto>()
            .ForMember(x => x.Image,
                opt => opt.MapFrom(src => new Image(){Info = src.ImageInfo, Base64String = ""}));

        CreateMap<MemeCreateDto, Meme>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTimeOffset.UtcNow))
            .ForMember(x => x.AuthorId, opt => opt.MapFrom(src => Guid.Empty))
            .ForMember(x => x.ImageInfo, opt => opt.MapFrom(src => src.Image.Info));
    }
}
