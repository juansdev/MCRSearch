using MCRSearch.src.MCRSearch.Core.Entities;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces
{
    public interface IVehicleModelRepository
    {
        Task<List<VehicleModel>> GetVehicleModels();
        Task<VehicleModel?> GetVehicleModel(int id);
        Task<VehicleModel?> GetVehicleModel(string name);
        Task<bool> CreateVehicleModel(VehicleModel vehicleModel);
        Task<bool> UpdateVehicleModel(VehicleModel vehicleModel);
        Task<bool> DeleteVehicleModel(VehicleModel vehicleModel);
        Task<bool> Save();
    }
}
