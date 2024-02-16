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
        public async Task<List<VehicleModel>> GetVehicleModels()
        {
            return await _context.VehicleModels.OrderBy(vm => vm.Name).ToListAsync();
        }

        public async Task<VehicleModel?> GetVehicleModel(int id)
        {
            return await _context.VehicleModels.FirstOrDefaultAsync(vm => vm.Id == id);
        }

        public async Task<bool> IsAvailable(int id)
        {
            return await _context.VehicleModels.AnyAsync(vm => vm.Id == id);
        }

        public async Task<bool> IsAvailable(string name)
        {
            return await _context.VehicleModels.AnyAsync(vm => vm.Name.ToLower().Trim() == name.ToLower().Trim());
        }
    }
}
