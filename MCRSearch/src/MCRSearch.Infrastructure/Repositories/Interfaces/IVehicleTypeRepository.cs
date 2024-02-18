using MCRSearch.src.MCRSearch.Core.Entities;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces
{
    public interface IVehicleTypeRepository
    {
        Task<List<VehicleType>> GetVehicleTypes();
        Task<VehicleType?> GetVehicleType(int id);
        Task<VehicleType?> GetVehicleType(string name);
        Task<bool> CreateVehicleType(VehicleType vehicleType);
        Task<bool> UpdateVehicleType(VehicleType vehicleType);
        Task<bool> DeleteVehicleType(VehicleType vehicleType);
        Task<bool> Save();
    }
}
