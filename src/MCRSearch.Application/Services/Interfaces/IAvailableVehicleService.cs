using MCRSearch.src.MCRSearch.Application.Dtos;

namespace MCRSearch.src.MCRSearch.Application.Services.Interfaces
{
    public interface IAvailableVehicleService
    {
        public List<AvailableVehicleDto> GetAvailableVehicles(int pickUpCityId, int returnCityId);
        public bool IsEnabledMarket(int localizedCustomerCountryId, int pickUpCityId);
    }
}
