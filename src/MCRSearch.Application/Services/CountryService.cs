using AutoMapper;
using MCRSearch.src.MCRSearch.Application.Dtos;
using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using MCRSearch.src.MCRSearch.Presentation.Dtos;
using System.Net;

namespace MCRSearch.src.MCRSearch.Application.Services
{
    public class CountryService: ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private readonly ResponseAPI<Country> _responseApi;
        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
            _responseApi = new ResponseAPI<Country>();
        }

        /// <summary>
        /// Obtiene todos los paises.
        /// </summary>
        public List<CountryDto> GetCountries()
        {
            var listCountriesRepository = _countryRepository.GetCountries().Result;
            var listCountriesDto = new List<CountryDto>();
            foreach(var country in listCountriesRepository)
            {
                listCountriesDto.Add(_mapper.Map<CountryDto>(country));
            }
            return listCountriesDto;
        }

        /// <summary>
        /// Obtiene el pais por ID.
        /// </summary>
        public CountryDto GetCountry(int id)
        {
            var country = _countryRepository.GetCountry(id).Result;
            return _mapper.Map<CountryDto>(country);
        }

        /// <summary>
        /// Obtiene el pais por nombre.
        /// </summary>
        public CountryDto GetCountry(string name)
        {
            var country = _countryRepository.GetCountry(name).Result;
            return _mapper.Map<CountryDto>(country);
        }

        /// <summary>
        /// Crear el pais.
        /// </summary>
        public ResponseAPI<Country> CreateCountry(CountryPostDto countryDto)
        {
            if (_countryRepository.GetCountry(countryDto.Name).Result != null)
            {
                _responseApi.StatusCode = HttpStatusCode.BadRequest;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add("El nombre del pais ya existe");
                return _responseApi;
            }
            var country = _mapper.Map<Country>(countryDto);
            if (!_countryRepository.CreateCountry(country).Result)
            {
                _responseApi.StatusCode = HttpStatusCode.InternalServerError;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add($"Algo salio mal guardando el registro {country.Name}");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.OK;
            _responseApi.IsSuccess = true;
            _responseApi.Result = country;
            return _responseApi;
        }

        /// <summary>
        /// Actualizar el pais.
        /// </summary>
        public ResponseAPI<Country> PatchCountry(CountryPatchDto countryDto)
        {
            var country = _mapper.Map<Country>(countryDto);
            if (!_countryRepository.UpdateCountry(country).Result)
            {
                _responseApi.StatusCode = HttpStatusCode.InternalServerError;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add($"Algo salio mal guardando el registro {country.Name}");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.NoContent;
            _responseApi.IsSuccess = true;
            return _responseApi;
        }

        /// <summary>
        /// Eliminar el pais.
        /// </summary>
        public ResponseAPI<Country> DeleteCountry(int countryId)
        {
            var country = _countryRepository.GetCountry(countryId).Result;
            if (!_countryRepository.DeleteCountry(country).Result)
            {
                _responseApi.StatusCode = HttpStatusCode.InternalServerError;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add($"Algo salio mal eliminando el registro {country.Name}");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.NoContent;
            _responseApi.IsSuccess = true;
            return _responseApi;
        }
    }
}
