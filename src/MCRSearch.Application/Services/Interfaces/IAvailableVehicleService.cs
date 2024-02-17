using MCRSearch.src.MCRSearch.Application.Dtos;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Presentation.Dtos;

namespace MCRSearch.src.MCRSearch.Application.Services.Interfaces
{
    public interface IAvailableVehicleService
    {
        List<AvailableVehicleWithVehicleDto> GetAvailableVehicles(string pickUpCityName, string returnCityName);
        List<AvailableVehicleWithVehicleDto> GetAvailableVehicles(int pickUpCityId, int returnCityId);
        AvailableVehicleDto GetAvailableVehicle(int id);
        List<AvailableVehicleWithVehicleDto> GetAvailableVehiclesInVehicle(int vehicleId);
        List<AvailableVehicleWithCityDto> GetAvailableVehiclesInCity(int cityId);
        bool IsEnabledMarket(int localizedCustomerCountryId, int pickUpCityId);
        bool IsEnabledMarket(string localizedCustomerCountryName, string pickUpCityName);
        ResponseAPI<AvailableVehicle> CreateAvailableVehicle(AvailableVehicleDto availableVehicleDto);
        ResponseAPI<AvailableVehicle> PatchAvailableVehicle(AvailableVehicleDto availableVehicleDto);
        ResponseAPI<AvailableVehicle> DeleteAvailableVehicle(int availableVehicleId);
    }
}
