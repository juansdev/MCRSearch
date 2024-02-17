using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;
        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los paises.
        /// </summary>
        public async Task<List<Country>> GetCountries()
        {
            return await _context.Countries.OrderBy(c => c.Name).ToListAsync();
        }

        /// <summary>
        /// Obtiene el pais segun el ID.
        /// </summary>

        public async Task<Country?> GetCountry(int id)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Obtiene el pais segun el nombre.
        /// </summary>

        public async Task<Country?> GetCountry(string name)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        /// <summary>
        /// Crea un pais.
        /// </summary>
        public async Task<bool> CreateCountry(Country country)
        {
            country.CreateDate = DateTime.Now;
            await _context.Countries.AddAsync(country);
            return await Save();
        }

        /// <summary>
        /// Actualiza un pais.
        /// </summary>
        public async Task<bool> UpdateCountry(Country country)
        {
            country.UpdatedDate = DateTime.Now;
            _context.Countries.Update(country);
            return await Save();
        }

        /// <summary>
        /// Elimina un pais.
        /// </summary>
        public async Task<bool> DeleteCountry(Country country)
        {
            _context.Countries.Remove(country);
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
