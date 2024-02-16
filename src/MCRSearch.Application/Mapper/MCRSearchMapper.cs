using AutoMapper;
using MCRSearch.src.MCRSearch.Application.Dtos;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure.Dtos;

namespace MCRSearch.src.MCRSearch.Application.Mapper
{
    public class MCRSearchMapper: Profile
    {
        public MCRSearchMapper()
        {
            CreateMap<AppUser, AppUserDataDto>().ReverseMap();
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            CreateMap<AvailableVehicle, AvailableVehicleDto>().ReverseMap();
        }
    }
}
