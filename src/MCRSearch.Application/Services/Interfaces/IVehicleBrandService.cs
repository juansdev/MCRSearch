using MCRSearch.src.MCRSearch.Application.Dtos;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Presentation.Dtos;

namespace MCRSearch.src.MCRSearch.Application.Services.Interfaces
{
    public interface IVehicleBrandService
    {
        List<VehicleBrandDto> GetVehicleBrands();
        VehicleBrandDto GetVehicleBrand(int id);
        VehicleBrandDto GetVehicleBrand(string name);
        ResponseAPI<VehicleBrand> CreateVehicleBrand(VehicleBrandPostDto vehicleBrandDto);
        ResponseAPI<VehicleBrand> PatchVehicleBrand(VehicleBrandPatchDto vehicleBrandDto);
        ResponseAPI<VehicleBrand> DeleteVehicleBrand(int vehicleBrandId);
    }
}
