using AutoMapper;
using NZWalksWebApi.DTO;
using NZWalksWebApi.Models.Domains;

namespace NZWalksWebApi.Mappings
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<RegionDto, Region>()
                .ForMember(x => x.FullName, y => y.MapFrom(x => x.Name))
                .ReverseMap();
            CreateMap<RegionRequestDTO, Region>().ReverseMap();
            CreateMap<WalkRequestDTO, Walk>().ReverseMap();
            CreateMap<WalkDTO, Walk>().ReverseMap();
            CreateMap<DifficultyDTO, Difficulty>().ReverseMap();
        }
    }
}
