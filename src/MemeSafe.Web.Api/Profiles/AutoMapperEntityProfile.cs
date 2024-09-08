using AutoMapper;
using MemeSafe.Data.Entity;

namespace MemeSafe.Web.Api;

public class AutoMapperEntityProfile : Profile
{
    public AutoMapperEntityProfile()
    {
        CreateMap<Meme, MemeShowDTO>().ReverseMap();

        CreateMap<MemeCreateDto, Meme>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTimeOffset.UtcNow));
    }
}
