using MCRSearch.src.MCRSearch.Core.Entities;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces
{
    public interface ICityRepository
    {
        Task<List<City>> GetCities();
        Task<City?> GetCity(int id);
        Task<City?> GetCity(string name);
        Task<List<City>> GetCityInDepartment(int departmentId);
        Task<bool> CreateCity(City city);
        Task<bool> UpdateCity(City city);
        Task<bool> DeleteCity(City city);
        Task<bool> Save();
    }
}
