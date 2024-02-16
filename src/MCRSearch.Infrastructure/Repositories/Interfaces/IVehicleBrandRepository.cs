using MCRSearch.src.MCRSearch.Core.Entities;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces
{
    public interface IVehicleBrandRepository
    {
        Task<List<VehicleBrand>> GetVehicleBrands();
        Task<VehicleBrand?> GetVehicleBrand(int id);
        Task<VehicleBrand?> GetVehicleBrand(string name);
        Task<bool> IsAvailable(int id);
        Task<bool> IsAvailable(string name);
    }
}
