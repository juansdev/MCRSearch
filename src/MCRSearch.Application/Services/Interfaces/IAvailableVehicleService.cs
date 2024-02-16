using MCRSearch.src.MCRSearch.Application.Dtos;

namespace MCRSearch.src.MCRSearch.Application.Services.Interfaces
{
    public interface IAvailableVehicleService
    {
        public List<AvailableVehicleWithVehicleDto> GetAvailableVehicles(int pickUpCityId, int returnCityId);
        public List<AvailableVehicleWithVehicleDto> GetAvailableVehiclesInVehicle(int vehicleId);
        public List<AvailableVehicleWithCityDto> GetAvailableVehiclesInCity(int cityId);
        public bool IsEnabledMarket(int localizedCustomerCountryId, int pickUpCityId);
    }
}
