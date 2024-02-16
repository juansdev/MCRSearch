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
        public async Task<List<VehicleBrand>> GetVehicleBrands()
        {
            return await _context.VehicleBrands.OrderBy(vb => vb.Name).ToListAsync();
        }

        public async Task<VehicleBrand?> GetVehicleBrand(int id)
        {
            return await _context.VehicleBrands.FirstOrDefaultAsync(vb => vb.Id == id);
        }

        public async Task<VehicleBrand?> GetVehicleBrand(string name)
        {
            return await _context.VehicleBrands.FirstOrDefaultAsync(vb => vb.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        public async Task<bool> IsAvailable(int id)
        {
            return await _context.VehicleBrands.AnyAsync(vb => vb.Id == id);
        }

        public async Task<bool> IsAvailable(string name)
        {
            return await _context.VehicleBrands.AnyAsync(vb => vb.Name.ToLower().Trim() == name.ToLower().Trim());
        }
    }
}
