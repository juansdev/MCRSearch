using MCRSearch.src.MCRSearch.Core.Entities;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces
{
    public interface IVehicleTypeRepository
    {
        Task<List<VehicleType>> GetVehicleTypes();
        Task<VehicleType?> GetVehicleType(int id);
        Task<VehicleType?> GetVehicleType(string name);
        Task<bool> IsAvailable(int id);
        Task<bool> IsAvailable(string name);
    }
}
