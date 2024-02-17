using AutoMapper;
using MCRSearch.src.MCRSearch.Application.Dtos;
using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using MCRSearch.src.MCRSearch.Presentation.Dtos;
using System.Net;

namespace MCRSearch.src.MCRSearch.Application.Services
{
    public class AvailableVehicleService: IAvailableVehicleService
    {
        private readonly IAvailableVehicleRepository _availableVehicleRepository;
        private readonly IMapper _mapper;
        private readonly ResponseAPI<AvailableVehicle> _responseApi;
        public AvailableVehicleService(IAvailableVehicleRepository availableVehicleRepository, IMapper mapper)
        {
            _availableVehicleRepository = availableVehicleRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene los vehiculos disponibles por ciudad de recogida y de retorno por nombre.
        /// </summary>
        public List<AvailableVehicleWithVehicleDto> GetAvailableVehicles(string pickUpCityName, string returnCityName)
        {
            var listAvailableVehicleRepository = _availableVehicleRepository.GetAvailableVehicles(pickUpCityName, returnCityName).Result;
            var listAvailableVehicleRepositoryDto = new List<AvailableVehicleWithVehicleDto>();
            foreach (var availableVehicle in listAvailableVehicleRepository)
            {
                listAvailableVehicleRepositoryDto.Add(_mapper.Map<AvailableVehicleWithVehicleDto>(availableVehicle));
            }
            return listAvailableVehicleRepositoryDto;
        }

        /// <summary>
        /// Obtiene los vehiculos disponibles por ciudad de recogida y de retorno por ID.
        /// </summary>
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

        /// <summary>
        /// Obtiene un vehiculo disponible por ID.
        /// </summary>
        public AvailableVehicleDto GetAvailableVehicle(int id)
        {
            var availableVehicle = _availableVehicleRepository.GetAvailableVehicle(id).Result;
            return _mapper.Map<AvailableVehicleDto>(availableVehicle);
        }

        /// <summary>
        /// Obtiene los vehiculos disponibles por clase de vehiculo.
        /// </summary>
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


        /// <summary>
        /// Obtiene los vehiculos disponibles por Ciudad.
        /// </summary>
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

        public bool IsEnabledMarket(string localizedCustomerCountryName, string pickUpCityName)
        {
            var isEnabledMarket = _availableVehicleRepository.IsEnabledMarket(localizedCustomerCountryName, pickUpCityName).Result;
            return isEnabledMarket;
        }

        public bool IsEnabledMarket(int localizedCustomerCountryId, int pickUpCityId)
        {
            var isEnabledMarket = _availableVehicleRepository.IsEnabledMarket(localizedCustomerCountryId, pickUpCityId).Result;
            return isEnabledMarket;
        }

        /// <summary>
        /// Agrega a disponibilidad un vehiculo.
        /// </summary>
        public ResponseAPI<AvailableVehicle> CreateAvailableVehicle(AvailableVehicleDto availableVehicleDto)
        {
            if (_availableVehicleRepository.GetAvailableVehicle(availableVehicleDto.VehicleId).Result != null)
            {
                _responseApi.StatusCode = HttpStatusCode.BadRequest;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add("El vehiculo ya se encuentra en disponibilidad");
                return _responseApi;
            }
            var availableVehicle = _mapper.Map<AvailableVehicle>(availableVehicleDto);
            if (!_availableVehicleRepository.CreateAvailableVehicle(availableVehicle).Result)
            {
                _responseApi.StatusCode = HttpStatusCode.InternalServerError;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add($"Algo salio mal guardando el registro.");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.OK;
            _responseApi.IsSuccess = true;
            _responseApi.Result = availableVehicle;
            return _responseApi;
        }

        /// <summary>
        /// Actualiza la disponibilidad de un vehiculo.
        /// </summary>
        public ResponseAPI<AvailableVehicle> PatchAvailableVehicle(AvailableVehicleDto availableVehicleDto)
        {
            var availableVehicle = _mapper.Map<AvailableVehicle>(availableVehicleDto);
            if (!_availableVehicleRepository.UpdateAvailableVehicle(availableVehicle).Result)
            {
                _responseApi.StatusCode = HttpStatusCode.InternalServerError;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add($"Algo salio mal guardando el registro.");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.NoContent;
            _responseApi.IsSuccess = true;
            return _responseApi;
        }

        /// <summary>
        /// Eliminar la disponibilidad de un vehiculo.
        /// </summary>
        public ResponseAPI<AvailableVehicle> DeleteAvailableVehicle(int availableVehicleId)
        {
            var availableVehicle = _availableVehicleRepository.GetAvailableVehicle(availableVehicleId).Result;
            if (!_availableVehicleRepository.DeleteAvailableVehicle(availableVehicle).Result)
            {
                _responseApi.StatusCode = HttpStatusCode.InternalServerError;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add($"Algo salio mal eliminando el registro.");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.NoContent;
            _responseApi.IsSuccess = true;
            return _responseApi;
        }
    }
}
