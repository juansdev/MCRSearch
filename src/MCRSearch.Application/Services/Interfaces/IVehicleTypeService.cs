using MCRSearch.src.MCRSearch.Application.Dtos;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Presentation.Dtos;

namespace MCRSearch.src.MCRSearch.Application.Services.Interfaces
{
    public interface IVehicleTypeService
    {
        List<VehicleTypeDto> GetVehicleTypes();
        VehicleTypeDto GetVehicleType(int id);
        VehicleTypeDto GetVehicleType(string name);
        ResponseAPI<VehicleType> CreateVehicleType(VehicleTypeDto vehicleTypeDto);
        ResponseAPI<VehicleType> PatchVehicleType(VehicleTypeDto vehicleTypeDto);
        ResponseAPI<VehicleType> DeleteVehicleType(int vehicleTypeId);
    }
}
