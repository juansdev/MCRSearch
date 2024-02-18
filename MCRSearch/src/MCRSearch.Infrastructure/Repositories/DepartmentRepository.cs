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

        /// <summary>
        /// Obtiene todos los departamentos.
        /// </summary>
        public async Task<List<Department>> GetDepartments()
        {
            return await _context.Departments
                .Include(d => d.Country)
                .OrderBy(d => d.Name).ToListAsync();
        }

        /// <summary>
        /// Obtiene el departamento segun la ID.
        /// </summary>
        public async Task<Department?> GetDepartment(int id)
        {
            return await _context.Departments
                .Include(d => d.Country)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        /// <summary>
        /// Obtiene el departamento segun el nombre.
        /// </summary>
        public async Task<Department?> GetDepartment(string name)
        {
            return await _context.Departments
                .Include(d => d.Country)
                .FirstOrDefaultAsync(d => d.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        /// <summary>
        /// Obtiene todos los departamentos en el pais.
        /// </summary>
        public async Task<List<Department>> GetDepartmentInCountry(int countryId)
        {
            return await _context.Departments
                .Include(d => d.Country)
                .Where(co => co.CountryId == countryId).ToListAsync();
        }

        /// <summary>
        /// Crea un registro de departamento.
        /// </summary>
        public async Task<bool> CreateDeparment(Department department)
        {
            department.CreateDate = DateTime.Now;
            await _context.Departments.AddAsync(department);
            return await Save();
        }

        /// <summary>
        /// Actualiza un registro de departamento.
        /// </summary>
        public async Task<bool> UpdateDepartmentModel(Department department)
        {
            department.UpdatedDate = DateTime.Now;
            _context.Departments.Update(department);
            return await Save();
        }

        /// <summary>
        /// Elimina un registro de departamento.
        /// </summary>
        public async Task<bool> DeleteDepartmentModel(Department department)
        {
            _context.Departments.Remove(department);
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
