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
        public async Task<List<AvailableVehicle>> GetAvailableVehicles(int pickUpCityId, int returnCityId)
        {
            return await _context.AvailableVehicles.Where(av=>av.PickUpCityId == pickUpCityId && av.ReturnCityId == returnCityId).ToListAsync();
        }

        public async Task<AvailableVehicle?> GetAvailableVehicle(int id)
        {
            return await _context.AvailableVehicles.FirstOrDefaultAsync(av => av.Id == id);
        }

        public async Task<AvailableVehicle?> GetAvailableVehicle(int vehicleId, int cityId)
        {
            return await _context.AvailableVehicles
                .Include(av => av.Vehicle)
                .Include(av => av.PickUpCity)
                .Include(av => av.ReturnCity)
                .FirstOrDefaultAsync(
                    av => av.VehicleId == vehicleId &&
                          av.PickUpCityId == cityId || av.ReturnCityId == cityId
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
            return await _context.AvailableVehicles
                .Include(av => av.ReturnCity)
                .Include(av => av.PickUpCity)
                .Where(c => c.PickUpCityId == cityId || c.ReturnCityId == cityId).ToListAsync();
        }

        public async Task<bool> IsEnabledMarket(int localizedCustomerCountryId, int pickUpCityId)
        {
            return await _context.AvailableVehicles
                .Include(av => av.PickUpCity.Department)
                .AnyAsync(av => av.PickUpCityId == pickUpCityId && av.PickUpCity.Department.CountryId == localizedCustomerCountryId);
        }
    }
}
