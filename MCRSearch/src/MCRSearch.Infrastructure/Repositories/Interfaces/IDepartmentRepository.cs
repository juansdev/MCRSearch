using MCRSearch.src.MCRSearch.Core.Entities;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetDepartments();
        Task<Department?> GetDepartment(int id);
        Task<Department?> GetDepartment(string name);
        Task<List<Department>> GetDepartmentInCountry(int countryId);
        Task<bool> CreateDeparment(Department department);
        Task<bool> UpdateDepartmentModel(Department department);
        Task<bool> DeleteDepartmentModel(Department department);
        Task<bool> Save();
    }
}
