using AutoMapper;
using Web_API.Models.Domain;
using Web_API.Models.DTO.RequestDTO;
using Web_API.Models.DTO.ResponseDTO;

namespace Web_API.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {   
            // Region
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<Region, AddRegionDTO>().ReverseMap();
            CreateMap<Region, UpdateRegionDTO>().ReverseMap();

            //Walk
            CreateMap<Walk,AddWalkDTO>().ReverseMap();
            CreateMap<Walk,WalkDTO>().ReverseMap();
            CreateMap<Walk, UpdateWalkDTO>().ReverseMap();

            //Difficulty
            CreateMap<Difficulty, DifficultyDTO>().ReverseMap();

        }
    }
}
