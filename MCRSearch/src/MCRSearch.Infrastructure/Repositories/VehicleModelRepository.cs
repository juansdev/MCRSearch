using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly ApplicationDbContext _context;
        public VehicleModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los modelos del vehiculo.
        /// </summary>
        public async Task<List<VehicleModel>> GetVehicleModels()
        {
            return await _context.VehicleModels.OrderBy(vm => vm.Name).ToListAsync();
        }

        /// <summary>
        /// Obtiene el modelo del vehiculo segun el ID.
        /// </summary>
        public async Task<VehicleModel?> GetVehicleModel(int id)
        {
            return await _context.VehicleModels.FirstOrDefaultAsync(vm => vm.Id == id);
        }

        /// <summary>
        /// Obtiene el modelo del vehiculo segun el nombre.
        /// </summary>
        public async Task<VehicleModel?> GetVehicleModel(string name)
        {
            return await _context.VehicleModels.FirstOrDefaultAsync(vm => vm.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        /// <summary>
        /// Crea un registro de modelo de vehiculo.
        /// </summary>
        public async Task<bool> CreateVehicleModel(VehicleModel vehicleModel)
        {
            vehicleModel.CreateDate = DateTime.Now;
            await _context.VehicleModels.AddAsync(vehicleModel);
            return await Save();
        }

        /// <summary>
        /// Actualiza un registro de modelo de vehiculo.
        /// </summary>
        public async Task<bool> UpdateVehicleModel(VehicleModel vehicleModel)
        {
            vehicleModel.UpdatedDate = DateTime.Now;
            _context.VehicleModels.Update(vehicleModel);
            return await Save();
        }

        /// <summary>
        /// Elimina un registro de modelo de vehiculo.
        /// </summary>
        public async Task<bool> DeleteVehicleModel(VehicleModel vehicleModel)
        {
            _context.VehicleModels.Remove(vehicleModel);
            return await Save();
        }

        /// <summary>
        /// Guarda los cambios en la BD.
        /// </summary>
        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
