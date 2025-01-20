using AutoMapper;
using VNWalks.API.Models.Domain;
using VNWalks.API.Models.DTO;

namespace VNWalks.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Region
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();

            // Walk
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();

            // Difficulty
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
        }
    }
}
