using MCRSearch.src.MCRSearch.Application.Dtos;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Presentation.Dtos;

namespace MCRSearch.src.MCRSearch.Application.Services.Interfaces
{
    public interface ICountryService
    {
        List<CountryDto> GetCountries();
        CountryDto GetCountry(int id);
        CountryDto GetCountry(string name);
        ResponseAPI<Country> CreateCountry(CountryDto countryDto);
        ResponseAPI<Country> PatchCountry(CountryDto countryDto);
        ResponseAPI<Country> DeleteCountry(int countryId);
    }
}
