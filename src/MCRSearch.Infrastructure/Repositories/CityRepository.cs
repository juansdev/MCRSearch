using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _context;
        public CityRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<City>> GetCities()
        {
            return await _context.Cities.OrderBy(d => d.Name).ToListAsync();
        }

        public async Task<City?> GetCity(int id)
        {
            return await _context.Cities.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<bool> IsAvailable(int id)
        {
            return await _context.Cities.AnyAsync(d => d.Id == id);
        }

        public async Task<bool> IsAvailable(string name)
        {
            return await _context.Cities.AnyAsync(d=>d.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        public async Task<List<City>> GetCityInDepartment(int departmentId)
        {
            return await _context.Cities.Include(d => d.Department).Where(co => co.DepartmentId == departmentId).ToListAsync();
        }
    }
}
