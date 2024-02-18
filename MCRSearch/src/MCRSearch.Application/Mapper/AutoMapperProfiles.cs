using AutoMapper;
using MCRSearch.src.MCRSearch.Application.Dtos;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.SharedDtos;

namespace MCRSearch.src.MCRSearch.Application.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, AppUserLoginDataDto>().ReverseMap();
            CreateMap<AppUser, AppUserDto>().ReverseMap();

            CreateMap<AvailableVehicle, AvailableVehicleDto>().ReverseMap();
            CreateMap<AvailableVehicle, AvailableVehiclePatchDto>().ReverseMap();
            CreateMap<AvailableVehicle, AvailableVehiclePostDto>().ReverseMap();

            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, CountryPostDto>().ReverseMap();
            CreateMap<Country, CountryPatchDto>().ReverseMap();

            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Department, DepartmentPostDto>().ReverseMap();
            CreateMap<Department, DepartmentPatchDto>().ReverseMap();

            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<City, CityPostDto>().ReverseMap();
            CreateMap<City, CityPatchDto>().ReverseMap();

            CreateMap<VehicleBrand, VehicleBrandDto>().ReverseMap();
            CreateMap<VehicleBrand, VehicleBrandPostDto>().ReverseMap();
            CreateMap<VehicleBrand, VehicleBrandPatchDto>().ReverseMap();

            CreateMap<VehicleType, VehicleTypeDto>().ReverseMap();
            CreateMap<VehicleType, VehicleTypePostDto>().ReverseMap();
            CreateMap<VehicleType, VehicleTypePatchDto>().ReverseMap();

            CreateMap<VehicleModel, VehicleModelDto>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelPostDto>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelPatchDto>().ReverseMap();

            CreateMap<Vehicle, VehicleDto>().ReverseMap();
            CreateMap<Vehicle, VehiclePostDto>().ReverseMap();
            CreateMap<Vehicle, VehiclePatchDto>().ReverseMap();
        }
    }
}
