using MCRSearch.src.MCRSearch.Core.Entities;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces
{
    public interface IVehicleModelRepository
    {
        Task<List<VehicleModel>> GetVehicleModels();
        Task<VehicleModel?> GetVehicleModel(int id);
        Task<VehicleModel?> GetVehicleModel(string name);
        Task<bool> IsAvailable(int id);
        Task<bool> IsAvailable(string name);
    }
}
