using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.SharedDtos;

namespace MCRSearch.src.MCRSearch.Application.Services.Interfaces
{
    public interface IAvailableVehicleService
    {
        List<AvailableVehicleDto> GetAvailableVehicles(string pickUpCityName, string returnCityName);
        List<AvailableVehicleDto> GetAvailableVehicles(int pickUpCityId, int returnCityId);
        AvailableVehicleDto GetAvailableVehicle(int id);
        List<AvailableVehicleDto> GetAvailableVehiclesInVehicle(int vehicleId);
        List<AvailableVehicleDto> GetAvailableVehiclesInCity(int cityId);
        bool IsEnabledMarket(int localizedCustomerCountryId, int pickUpCityId);
        bool IsEnabledMarket(string localizedCustomerCountryName, string pickUpCityName);
        ResponseAPI<AvailableVehicle> CreateAvailableVehicle(AvailableVehiclePostDto availableVehicleDto);
        ResponseAPI<AvailableVehicle> PatchAvailableVehicle(AvailableVehiclePatchDto availableVehicleDto);
        ResponseAPI<AvailableVehicle> DeleteAvailableVehicle(int availableVehicleId);
    }
}
