using AutoMapper;
using MCRSearch.src.MCRSearch.Application.Dtos;
using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.MCRSearch.Core.Entities;
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
        public List<AvailableVehicleDto> GetAvailableVehicles(int pickUpCityId, int returnCityId)
        {
            var listAvailableVehicleRepository = _availableVehicleRepository.GetAvailableVehicles(pickUpCityId, returnCityId).Result;
            var listAvailableVehicleRepositoryDto = new List<AvailableVehicleDto>();
            foreach(var availableVehicle in listAvailableVehicleRepository)
            {
                listAvailableVehicleRepositoryDto.Add(_mapper.Map<AvailableVehicleDto>(availableVehicle));
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
