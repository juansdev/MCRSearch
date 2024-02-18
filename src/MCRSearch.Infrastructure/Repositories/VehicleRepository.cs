using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext _context;
        public VehicleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los vehiculos.
        /// </summary>
        public async Task<List<Vehicle>> GetVehicles()
        {
            return await _context.Vehicles
                    .Include(v => v.VehicleModel)
                    .Include(v => v.VehicleBrand)
                    .Include(v => v.VehicleType)
                    .ToListAsync();
        }

        /// <summary>
        /// Obtiene el vehiculo segun la ID.
        /// </summary>
        public async Task<Vehicle?> GetVehicle(int id)
        {
            return await _context.Vehicles
                    .Include(v => v.VehicleModel)
                    .Include(v => v.VehicleBrand)
                    .Include(v => v.VehicleType)
                    .FirstOrDefaultAsync(ve => ve.Id == id);
        }

        /// <summary>
        /// Obtiene el vehiculo segun el nombre del modelo, del tipo y de la marca.
        /// </summary>
        public async Task<Vehicle?> GetVehicle(string modelName, string typeName, string brandName)
        {
            return await _context.Vehicles
                .Include(ve => ve.VehicleModel)
                .Include(ve => ve.VehicleType)
                .Include(ve => ve.VehicleBrand)
                .FirstOrDefaultAsync(
                    ve => ve.VehicleModel.Name.ToLower().Trim() == modelName.ToLower().Trim() &&
                          ve.VehicleType.Name.ToLower().Trim() == typeName.ToLower().Trim() &&
                          ve.VehicleBrand.Name.ToLower().Trim() == brandName.ToLower().Trim()
                );
        }

        /// <summary>
        /// Obtiene el vehiculo segun el ID del modelo, del tipo y de la marca.
        /// </summary>
        public async Task<Vehicle?> GetVehicle(int modelId, int typeId, int brandId)
        {
            return await _context.Vehicles
                .Include(ve => ve.VehicleModel)
                .Include(ve => ve.VehicleType)
                .Include(ve => ve.VehicleBrand)
                .FirstOrDefaultAsync(
                    ve => ve.VehicleModelId == modelId && 
                          ve.VehicleTypeId == typeId && 
                          ve.VehicleBrandId == brandId
                );
        }

        /// <summary>
        /// Obtiene todos los vehiculos según el modelo.
        /// </summary>
        public async Task<List<Vehicle>> GetVehiclesInModel(int modelId)
        {
            return await _context.Vehicles
                    .Include(v => v.VehicleModel)
                    .Include(v => v.VehicleBrand)
                    .Include(v => v.VehicleType)
                    .Include(ve=>ve.VehicleModel).Where(vm=>vm.VehicleModelId == modelId).ToListAsync();
        }

        /// <summary>
        /// Obtiene todos los vehiculos segun el tipo.
        /// </summary>
        public async Task<List<Vehicle>> GetVehiclesInType(int typeId)
        {
            return await _context.Vehicles
                    .Include(v => v.VehicleModel)
                    .Include(v => v.VehicleBrand)
                    .Include(v => v.VehicleType)
                    .Include(ve => ve.VehicleType).Where(vt => vt.VehicleTypeId == typeId).ToListAsync();
        }

        /// <summary>
        /// Obtiene todos los vehiculos segun la marca.
        /// </summary>
        public async Task<List<Vehicle>> GetVehiclesInBrand(int brandId)
        {
            return await _context.Vehicles
                    .Include(v => v.VehicleModel)
                    .Include(v => v.VehicleBrand)
                    .Include(v => v.VehicleType)
                    .Include(ve => ve.VehicleBrand).Where(vb => vb.VehicleTypeId == brandId).ToListAsync();
        }

        /// <summary>
        /// Crea un vehiculo.
        /// </summary>
        public async Task<bool> CreateVehicle(Vehicle vehicle)
        {
            vehicle.CreateDate = DateTime.Now;
            await _context.Vehicles.AddAsync(vehicle);
            return await Save();
        }

        public async Task<bool> UpdateVehicle(Vehicle vehicle)
        {
            vehicle.UpdatedDate = DateTime.Now;
            _context.Vehicles.Update(vehicle);
            return await Save();
        }

        public async Task<bool> DeleteVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Remove(vehicle);
            return await Save();
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
