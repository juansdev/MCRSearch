using MCRSearch.src.MCRSearch.Core.Entities;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces
{
    public interface IAvailableVehicleRepository
    {
        Task<List<AvailableVehicle>> GetAvailableVehicles();
        Task<AvailableVehicle?> GetAvailableVehicle(int id);
        Task<AvailableVehicle?> GetAvailableVehicle(int vehicleId, int cityId);
        Task<bool> IsAvailable(int id);
        Task<List<AvailableVehicle>> GetAvailableVehiclesInVehicle(int vehicleId);
        Task<List<AvailableVehicle>> GetAvailableVehiclesInCity(int cityId);
    }
}
