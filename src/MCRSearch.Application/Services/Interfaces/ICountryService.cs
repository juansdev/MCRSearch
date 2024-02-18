using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.SharedDtos;

namespace MCRSearch.src.MCRSearch.Application.Services.Interfaces
{
    public interface ICountryService
    {
        List<CountryDto> GetCountries();
        CountryDto GetCountry(int id);
        CountryDto GetCountry(string name);
        ResponseAPI<Country> CreateCountry(CountryPostDto countryDto);
        ResponseAPI<Country> PatchCountry(CountryPatchDto countryDto);
        ResponseAPI<Country> DeleteCountry(int countryId);
    }
}
