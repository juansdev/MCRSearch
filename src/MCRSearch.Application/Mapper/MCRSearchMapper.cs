using AutoMapper;
using MCRSearch.src.MCRSearch.Application.Dtos;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure.Dtos;
using MCRSearch.src.MCRSearch.Presentation.Dtos;

namespace MCRSearch.src.MCRSearch.Application.Mapper
{
    public class MCRSearchMapper: Profile
    {
        public MCRSearchMapper()
        {
            CreateMap<AppUser, AppUserDataDto>().ReverseMap();
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            CreateMap<AvailableVehicle, AvailableVehicleWithCityDto>().ReverseMap();
            CreateMap<AvailableVehicle, AvailableVehicleWithVehicleDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<VehicleBrand, VehicleBrandDto>().ReverseMap();
            CreateMap<VehicleType, VehicleTypeDto>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelDto>().ReverseMap();
            CreateMap<Vehicle, VehicleDto>().ReverseMap();
        }
    }
}
