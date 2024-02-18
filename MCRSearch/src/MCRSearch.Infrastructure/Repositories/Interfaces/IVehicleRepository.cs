using MCRSearch.src.MCRSearch.Core.Entities;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces
{
    public interface IVehicleRepository
    {
        Task<List<Vehicle>> GetVehicles();
        Task<Vehicle?> GetVehicle(int id);
        Task<Vehicle?> GetVehicle(string modelName, string typeName, string brandName);
        Task<Vehicle?> GetVehicle(int modelId, int typeId, int brandId);
        Task<List<Vehicle>> GetVehiclesInModel(int modelId);
        Task<List<Vehicle>> GetVehiclesInType(int typeId);
        Task<List<Vehicle>> GetVehiclesInBrand(int brandId);
        Task<bool> CreateVehicle(Vehicle vehicle);
        Task<bool> UpdateVehicle(Vehicle vehicle);
        Task<bool> DeleteVehicle(Vehicle vehicle);
        Task<bool> Save();
    }
}
