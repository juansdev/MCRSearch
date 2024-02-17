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

        /// <summary>
        /// Obtiene todas las ciudades.
        /// </summary>
        public async Task<List<City>> GetCities()
        {
            return await _context.Cities
                .Include(c=>c.Department)
                .ThenInclude(d=>d.Country)
                .OrderBy(c => c.Name).ToListAsync();
        }

        /// <summary>
        /// Obtiene la ciudad segun ID.
        /// </summary>
        public async Task<City?> GetCity(int id)
        {
            return await _context.Cities
                .Include(c => c.Department)
                .ThenInclude(d => d.Country)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Obtiene la ciudad segun el nombre.
        /// </summary>
        public async Task<City?> GetCity(string name)
        {
            return await _context.Cities
                .Include(c => c.Department)
                .ThenInclude(d => d.Country)
                .FirstOrDefaultAsync(c => c.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        /// <summary>
        /// Obtiene todas las ciudades segun el departamento.
        /// </summary>
        public async Task<List<City>> GetCityInDepartment(int departmentId)
        {
            return await _context.Cities
                .Include(c => c.Department)
                .ThenInclude(d => d.Country)
                .Where(c => c.DepartmentId == departmentId).ToListAsync();
        }

        /// <summary>
        /// Crear ciudad.
        /// </summary>
        public async Task<bool> CreateCity(City city)
        {
            city.CreateDate = DateTime.Now;
            await _context.Cities.AddAsync(city);
            return await Save();
        }

        /// <summary>
        /// Actualizar ciudad.
        /// </summary>
        public async Task<bool> UpdateCity(City city)
        {
            city.UpdatedDate = DateTime.Now;
            _context.Cities.Update(city);
            return await Save();
        }

        /// <summary>
        /// Eliminar ciudad.
        /// </summary>
        public async Task<bool> DeleteCity(City city)
        {
            _context.Cities.Remove(city);
            return await Save();
        }

        /// <summary>
        /// Guarda los cambios en la BD.
        /// </summary>
        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
