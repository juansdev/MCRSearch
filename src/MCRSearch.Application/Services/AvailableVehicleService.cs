using AutoMapper;
using MCRSearch.src.MCRSearch.Application.Dtos;
using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;

namespace MCRSearch.src.MCRSearch.Application.Services
{
    public class AvailableVehicleService: IAvailableVehicleService
    {
        private readonly IAvailableVehicleRepository _availableVehicleRepository;
        private readonly IMapper _mapper;
        public AvailableVehicleService(IAvailableVehicleRepository availableVehicleRepository, IMapper mapper)
        {
            _availableVehicleRepository = availableVehicleRepository;
            _mapper = mapper;
        }
        public List<AvailableVehicleWithVehicleDto> GetAvailableVehicles(int pickUpCityId, int returnCityId)
        {
            var listAvailableVehicleRepository = _availableVehicleRepository.GetAvailableVehicles(pickUpCityId, returnCityId).Result;
            var listAvailableVehicleRepositoryDto = new List<AvailableVehicleWithVehicleDto>();
            foreach(var availableVehicle in listAvailableVehicleRepository)
            {
                listAvailableVehicleRepositoryDto.Add(_mapper.Map<AvailableVehicleWithVehicleDto>(availableVehicle));
            }
            return listAvailableVehicleRepositoryDto;
        }

        public AvailableVehicleWithVehicleDto GetAvailable(int availableVehicleId)
        {
            var availableVehicle = _availableVehicleRepository.GetAvailableVehicle(availableVehicleId).Result;
            return _mapper.Map<AvailableVehicleWithVehicleDto>(availableVehicle);
        }

        public List<AvailableVehicleWithVehicleDto> GetAvailableVehiclesInVehicle(int vehicleId)
        {
            var listAvailableVehicleRepository = _availableVehicleRepository.GetAvailableVehiclesInVehicle(vehicleId).Result;
            var listAvailableVehicleRepositoryDto = new List<AvailableVehicleWithVehicleDto>();
            foreach (var availableVehicle in listAvailableVehicleRepository)
            {
                listAvailableVehicleRepositoryDto.Add(_mapper.Map<AvailableVehicleWithVehicleDto>(availableVehicle));
            }
            return listAvailableVehicleRepositoryDto;
        }

        public List<AvailableVehicleWithCityDto> GetAvailableVehiclesInCity(int cityId)
        {
            var listAvailableVehicleRepository = _availableVehicleRepository.GetAvailableVehiclesInVehicle(cityId).Result;
            var listAvailableVehicleRepositoryDto = new List<AvailableVehicleWithCityDto>();
            foreach (var availableVehicle in listAvailableVehicleRepository)
            {
                listAvailableVehicleRepositoryDto.Add(_mapper.Map<AvailableVehicleWithCityDto>(availableVehicle));
            }
            return listAvailableVehicleRepositoryDto;
        }

        public bool IsEnabledMarket(int localizedCustomerCountryId, int pickUpCityId)
        {
            var isEnabledMarket = _availableVehicleRepository.IsEnabledMarket(localizedCustomerCountryId, pickUpCityId).Result;
            return isEnabledMarket;
        }
    }
}
