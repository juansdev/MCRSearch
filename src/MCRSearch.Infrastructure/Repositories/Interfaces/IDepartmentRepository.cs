using MCRSearch.src.MCRSearch.Core.Entities;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetDepartments();
        Task<Department?> GetDepartment(int id);
        Task<Department?> GetDepartment(string name);
        Task<bool> IsAvailable(int id);
        Task<bool> IsAvailable(string name);
        Task<List<Department>> GetDepartmentInCountry(int countryId);
    }
}
