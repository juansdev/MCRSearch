using MCRSearch.src.MCRSearch.Application.Dtos;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Presentation.Dtos;

namespace MCRSearch.src.MCRSearch.Application.Services.Interfaces
{
    public interface IVehicleService
    {
        List<VehicleDto> GetVehicles();
        VehicleDto GetVehicle(int id);
        VehicleDto GetVehicle(string modelName, string typeName, string brandName);
        VehicleDto GetVehicle(int modelId, int typeId, int brandId);
        List<VehicleDto> GetVehiclesInModel(int modelId);
        List<VehicleDto> GetVehiclesInType(int typeId);
        List<VehicleDto> GetVehiclesInBrand(int brandId);
        ResponseAPI<Vehicle> CreateVehicle(VehiclePostDto vehicleDto);
        ResponseAPI<Vehicle> PatchVehicle(VehiclePatchDto vehicleDto);
        ResponseAPI<Vehicle> DeleteVehicle(int vehicleId);
    }
}
