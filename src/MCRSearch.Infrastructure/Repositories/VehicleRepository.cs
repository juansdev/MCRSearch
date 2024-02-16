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
        public async Task<List<Vehicle>> GetVehicles()
        {
            return await _context.Vehicles
                    .Include(v => v.VehicleModel)
                    .Include(v => v.VehicleBrand)
                    .Include(v => v.VehicleType)
                    .ToListAsync();
        }

        public async Task<Vehicle?> GetVehicle(int id)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(ve => ve.Id == id);
        }

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

        public async Task<bool> IsAvailable(int id)
        {
            return await _context.Vehicles.AnyAsync(ve => ve.Id == id);
        }

        public async Task<List<Vehicle>> GetVehiclesInModel(int modelId)
        {
            return await _context.Vehicles.Include(ve=>ve.VehicleModel).Where(vm=>vm.VehicleModelId == modelId).ToListAsync();
        }

        public async Task<List<Vehicle>> GetVehiclesInType(int typeId)
        {
            return await _context.Vehicles.Include(ve => ve.VehicleType).Where(vt => vt.VehicleTypeId == typeId).ToListAsync();
        }

        public async Task<List<Vehicle>> GetVehiclesInBrand(int brandId)
        {
            return await _context.Vehicles.Include(ve => ve.VehicleBrand).Where(vb => vb.VehicleTypeId == brandId).ToListAsync();
        }
    }
}
