using AutoMapper;
using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using MCRSearch.src.SharedDtos;
using System.Net;

namespace MCRSearch.src.MCRSearch.Application.Services
{
    public class CityService: ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        private readonly ResponseAPI<City> _responseApi;
        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
            _responseApi = new ResponseAPI<City>();
        }

        /// <summary>
        /// Obtiene todas las ciudades.
        /// </summary>
        public List<CityDto> GetCities()
        {
            var listCitiesRepository = _cityRepository.GetCities().Result;
            var listCitiesDto = new List<CityDto>();
            foreach(var city in listCitiesRepository)
            {
                listCitiesDto.Add(_mapper.Map<CityDto>(city));
            }
            return listCitiesDto;
        }

        /// <summary>
        /// Obtiene la ciudad por ID.
        /// </summary>
        public CityDto GetCity(int id)
        {
            var listCityRepository = _cityRepository.GetCity(id).Result;
            return _mapper.Map<CityDto>(listCityRepository);
        }

        /// <summary>
        /// Obtiene la ciudad por nombre.
        /// </summary>
        public CityDto GetCity(string name)
        {
            var listCityRepository = _cityRepository.GetCity(name).Result;
            return _mapper.Map<CityDto>(listCityRepository);
        }

        /// <summary>
        /// Crea la ciudad.
        /// </summary>
        public ResponseAPI<City> CreateCity(CityPostDto cityDto)
        {
            if (_cityRepository.GetCity(cityDto.Name).Result != null)
            {
                _responseApi.StatusCode = HttpStatusCode.BadRequest;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add("El nombre de la ciudad ya existe");
                return _responseApi;
            }
            var city = _mapper.Map<City>(cityDto);
            if (!_cityRepository.CreateCity(city).Result)
            {
                _responseApi.StatusCode = HttpStatusCode.InternalServerError;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add($"Algo salio mal guardando el registro {city.Name}");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.OK;
            _responseApi.IsSuccess = true;
            _responseApi.Result = city;
            return _responseApi;
        }

        /// <summary>
        /// Actualiza la ciudad.
        /// </summary>
        public ResponseAPI<City> PatchCity(CityPatchDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);
            if (!_cityRepository.UpdateCity(city).Result)
            {
                _responseApi.StatusCode = HttpStatusCode.InternalServerError;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add($"Algo salio mal guardando el registro {city.Name}");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.NoContent;
            _responseApi.IsSuccess = true;
            return _responseApi;
        }

        /// <summary>
        /// Elimnina la ciudad.
        /// </summary>
        public ResponseAPI<City> DeleteCity(int cityId)
        {
            var city = _cityRepository.GetCity(cityId).Result;
            if (!_cityRepository.DeleteCity(city).Result)
            {
                _responseApi.StatusCode = HttpStatusCode.InternalServerError;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add($"Algo salio mal eliminando el registro {city.Name}");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.NoContent;
            _responseApi.IsSuccess = true;
            return _responseApi;
        }
    }
}
