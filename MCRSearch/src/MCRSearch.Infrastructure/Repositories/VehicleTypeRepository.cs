using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories
{
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public VehicleTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los vehiculos segun el tipo.
        /// </summary>
        public async Task<List<VehicleType>> GetVehicleTypes()
        {
            return await _context.VehicleTypes.OrderBy(vt => vt.Name).ToListAsync();
        }

        /// <summary>
        /// Obtiene el vehiculo segun el tipo.
        /// </summary>
        public async Task<VehicleType?> GetVehicleType(int id)
        {
            return await _context.VehicleTypes.FirstOrDefaultAsync(vt => vt.Id == id);
        }

        /// <summary>
        /// Obtiene el vehiculo segun el nombre del tipo.
        /// </summary>
        public async Task<VehicleType?> GetVehicleType(string name)
        {
            return await _context.VehicleTypes.FirstOrDefaultAsync(vt => vt.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        /// <summary>
        /// Crea un tipo de vehiculo.
        /// </summary>
        public async Task<bool> CreateVehicleType(VehicleType vehicleType)
        {
            vehicleType.CreateDate = DateTime.Now;
            await _context.VehicleTypes.AddAsync(vehicleType);
            return await Save();
        }

        /// <summary>
        /// Actualiza un registro de tipo de vehiculo.
        /// </summary>
        public async Task<bool> UpdateVehicleType(VehicleType vehicleType)
        {
            vehicleType.UpdatedDate = DateTime.Now;
            _context.VehicleTypes.Update(vehicleType);
            return await Save();
        }

        /// <summary>
        /// Elimina un registro de tipo de vehiculo.
        /// </summary>
        public async Task<bool> DeleteVehicleType(VehicleType vehicleType)
        {
            _context.VehicleTypes.Remove(vehicleType);
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
