using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.SharedDtos;

namespace MCRSearch.src.MCRSearch.Application.Services.Interfaces
{
    public interface ICityService
    {
        List<CityDto> GetCities();
        CityDto GetCity(int id);
        CityDto GetCity(string name);
        ResponseAPI<City> CreateCity(CityPostDto cityDto);
        ResponseAPI<City> PatchCity(CityPatchDto cityDto);
        ResponseAPI<City> DeleteCity(int cityId);
    }
}
