using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.SharedDtos;

namespace MCRSearch.src.MCRSearch.Application.Services.Interfaces
{
    public interface IVehicleTypeService
    {
        List<VehicleTypeDto> GetVehicleTypes();
        VehicleTypeDto GetVehicleType(int id);
        VehicleTypeDto GetVehicleType(string name);
        ResponseAPI<VehicleType> CreateVehicleType(VehicleTypePostDto vehicleTypeDto);
        ResponseAPI<VehicleType> PatchVehicleType(VehicleTypePatchDto vehicleTypeDto);
        ResponseAPI<VehicleType> DeleteVehicleType(int vehicleTypeId);
    }
}
