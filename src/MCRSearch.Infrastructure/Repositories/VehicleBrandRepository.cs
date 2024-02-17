using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories
{
    public class VehicleBrandRepository : IVehicleBrandRepository
    {
        private readonly ApplicationDbContext _context;
        public VehicleBrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todas las marcas de los vehiculos.
        /// </summary>
        public async Task<List<VehicleBrand>> GetVehicleBrands()
        {
            return await _context.VehicleBrands.OrderBy(vb => vb.Name).ToListAsync();
        }

        /// <summary>
        /// Obtiene la marca del vehiculo segun la ID.
        /// </summary>
        public async Task<VehicleBrand?> GetVehicleBrand(int id)
        {
            return await _context.VehicleBrands.FirstOrDefaultAsync(vb => vb.Id == id);
        }

        /// <summary>
        /// Obtiene la marca del vehiculo segun el nombre.
        /// </summary>
        public async Task<VehicleBrand?> GetVehicleBrand(string name)
        {
            return await _context.VehicleBrands.FirstOrDefaultAsync(vb => vb.Name.ToLower().Trim() == name.ToLower().Trim());
        }


        /// <summary>
        /// Crea un registro de la marca del vehiculo.
        /// </summary>
        public async Task<bool> CreateVehicleBrand(VehicleBrand vehicleBrand)
        {
            vehicleBrand.CreateDate = DateTime.Now;
            await _context.VehicleBrands.AddAsync(vehicleBrand);
            return await Save();
        }

        /// <summary>
        /// Actualiza un registro de la marca del vehiculo.
        /// </summary>
        public async Task<bool> UpdateVehicleBrand(VehicleBrand vehicleBrand)
        {
            vehicleBrand.UpdatedDate = DateTime.Now;
            _context.VehicleBrands.Update(vehicleBrand);
            return await Save();
        }

        /// <summary>
        /// Elimina un registro de la marca del vehiculo.
        /// </summary>
        public async Task<bool> DeleteVehicleBrand(VehicleBrand vehicleBrand)
        {
            _context.VehicleBrands.Remove(vehicleBrand);
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
