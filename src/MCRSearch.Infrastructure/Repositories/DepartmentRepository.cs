using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Department>> GetDepartments()
        {
            return await _context.Departments.OrderBy(d => d.Name).ToListAsync();
        }

        public async Task<Department?> GetDepartment(int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<bool> IsAvailable(int id)
        {
            return await _context.Departments.AnyAsync(d => d.Id == id);
        }

        public async Task<bool> IsAvailable(string name)
        {
            return await _context.Departments.AnyAsync(d=>d.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        public async Task<List<Department>> GetDepartmentInCountry(int countryId)
        {
            return await _context.Departments.Include(d => d.Country).Where(co => co.CountryId == countryId).ToListAsync();
        }
    }
}
