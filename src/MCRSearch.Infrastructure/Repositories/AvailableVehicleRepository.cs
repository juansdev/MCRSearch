using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories
{
    public class AvailableVehicleRepository : IAvailableVehicleRepository
    {
        private readonly ApplicationDbContext _context;
        public AvailableVehicleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<AvailableVehicle>> GetAvailableVehicles()
        {
            return await _context.AvailableVehicles.ToListAsync();
        }

        public async Task<AvailableVehicle?> GetAvailableVehicle(int id)
        {
            return await _context.AvailableVehicles.FirstOrDefaultAsync(av => av.Id == id);
        }

        public async Task<AvailableVehicle?> GetAvailableVehicle(int vehicleId, int cityId)
        {
            return await _context.AvailableVehicles
                .Include(av => av.Vehicle)
                .Include(av => av.City)
                .FirstOrDefaultAsync(
                    av => av.VehicleId == vehicleId &&
                          av.CityId == cityId
                );
        }

        public async Task<bool> IsAvailable(int id)
        {
            return await _context.AvailableVehicles.AnyAsync(ve => ve.Id == id);
        }

        public async Task<List<AvailableVehicle>> GetAvailableVehiclesInVehicle(int vehicleId)
        {
            return await _context.AvailableVehicles.Include(av => av.Vehicle).Where(ve=> ve.VehicleId == vehicleId).ToListAsync();
        }

        public async Task<List<AvailableVehicle>> GetAvailableVehiclesInCity(int cityId)
        {
            return await _context.AvailableVehicles.Include(av => av.City).Where(c => c.CityId == cityId).ToListAsync();
        }
    }
}
