using MCRSearch.src.MCRSearch.Application.Dtos;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Presentation.Dtos;

namespace MCRSearch.src.MCRSearch.Application.Services.Interfaces
{
    public interface IVehicleModelService
    {
        List<VehicleModelDto> GetVehicleModels();
        VehicleModelDto GetVehicleModel(int id);
        VehicleModelDto GetVehicleModel(string name);
        ResponseAPI<VehicleModel> CreateVehicleModel(VehicleModelPostDto vehicleModelDto);
        ResponseAPI<VehicleModel> PatchVehicleModel(VehicleModelPatchDto vehicleModelDto);
        ResponseAPI<VehicleModel> DeleteVehicleModel(int vehicleModelId);
    }
}
