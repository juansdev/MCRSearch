using MCRSearch.src.MCRSearch.Core.Entities;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetCountries();
        Task<Country?> GetCountry(int id);
        Task<Country?> GetCountry(string name);
        Task<bool> IsAvailable(int id);
        Task<bool> IsAvailable(string name);
    }
}
