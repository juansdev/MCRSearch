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
        public async Task<List<VehicleType>> GetVehicleTypes()
        {
            return await _context.VehicleTypes.OrderBy(vt => vt.Name).ToListAsync();
        }

        public async Task<VehicleType?> GetVehicleType(int id)
        {
            return await _context.VehicleTypes.FirstOrDefaultAsync(vt => vt.Id == id);
        }

        public async Task<VehicleType?> GetVehicleType(string name)
        {
            return await _context.VehicleTypes.FirstOrDefaultAsync(vt => vt.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        public async Task<bool> IsAvailable(int id)
        {
            return await _context.VehicleTypes.AnyAsync(vt => vt.Id == id);
        }

        public async Task<bool> IsAvailable(string name)
        {
            return await _context.VehicleTypes.AnyAsync(vt => vt.Name.ToLower().Trim() == name.ToLower().Trim());
        }
    }
}
