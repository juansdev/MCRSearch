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
            return await _context.AvailableVehicles
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleModel)
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleBrand)
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleType)
                .Include(av => av.ReturnCity)
                .Include(av => av.PickUpCity).ToListAsync();
        }
        public async Task<List<AvailableVehicle>> GetAvailableVehicles(int pickUpCityId, int returnCityId)
        {
            return await _context.AvailableVehicles
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleModel)
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleBrand)
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleType)
                .Include(av => av.ReturnCity)
                .Include(av => av.PickUpCity)
                .Where(av=>av.PickUpCityId == pickUpCityId && av.ReturnCityId == returnCityId).ToListAsync();
        }

        public async Task<AvailableVehicle?> GetAvailableVehicle(int id)
        {
            return await _context.AvailableVehicles
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleModel)
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleBrand)
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleType)
                .Include(av => av.ReturnCity)
                .Include(av => av.PickUpCity)
                .FirstOrDefaultAsync(av => av.Id == id);
        }

        public async Task<List<AvailableVehicle>> GetAvailableVehiclesInVehicle(int vehicleId)
        {
            return await _context.AvailableVehicles
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleModel)
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleBrand)
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleType)
                .Include(av => av.ReturnCity)
                .Include(av => av.PickUpCity)
                .Where(ve=> ve.VehicleId == vehicleId).ToListAsync();
        }

        public async Task<List<AvailableVehicle>> GetAvailableVehiclesInCity(int cityId)
        {
            return await _context.AvailableVehicles
                .Include(av => av.ReturnCity)
                    .ThenInclude(c => c.Department)
                    .ThenInclude(d => d.Country)
                .Include(av => av.PickUpCity)
                    .ThenInclude(c => c.Department)
                    .ThenInclude(d => d.Country)
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
