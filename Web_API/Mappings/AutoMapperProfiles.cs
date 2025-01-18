using AutoMapper;
using Web_API.Models.Domain;
using Web_API.Models.DTO.ResponseDTO;

namespace Web_API.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
        }
    }
}
