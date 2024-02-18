using AutoMapper;
using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using MCRSearch.src.SharedDtos;
using System.Net;

namespace MCRSearch.src.MCRSearch.Application.Services
{
    public class VehicleBrandService: IVehicleBrandService
    {
        private readonly IVehicleBrandRepository _vehicleBrandRepository;
        private readonly IMapper _mapper;
        protected ResponseAPI<VehicleBrand> _responseApi;
        public VehicleBrandService(IVehicleBrandRepository vehicleBrandRepository, IMapper mapper)
        {
            _vehicleBrandRepository = vehicleBrandRepository;
            _mapper = mapper;
            _responseApi = new ResponseAPI<VehicleBrand>();
        }

        /// <summary>
        /// Obtiene todas las marcas de vehiculos.
        /// </summary>
        public List<VehicleBrandDto> GetVehicleBrands()
        {
            var listVehicleBrandsRepository = _vehicleBrandRepository.GetVehicleBrands().Result;
            var listVehicleBrandsDto = new List<VehicleBrandDto>();
            foreach(var country in listVehicleBrandsRepository)
            {
                listVehicleBrandsDto.Add(_mapper.Map<VehicleBrandDto>(country));
            }
            return listVehicleBrandsDto;
        }

        /// <summary>
        /// Obtiene la marca de vehiculo por ID.
        /// </summary>
        public VehicleBrandDto GetVehicleBrand(int vehicleBrandId)
        {
            var vehicleBrandRepository = _vehicleBrandRepository.GetVehicleBrand(vehicleBrandId).Result;
            return _mapper.Map<VehicleBrandDto>(vehicleBrandRepository);
        }

        /// <summary>
        /// Obtiene la marca de vehiculo por Nombre.
        /// </summary>
        public VehicleBrandDto GetVehicleBrand(string vehicleBrandName)
        {
            var vehicleBrandRepository = _vehicleBrandRepository.GetVehicleBrand(vehicleBrandName).Result;
            return _mapper.Map<VehicleBrandDto>(vehicleBrandRepository);
        }

        /// <summary>
        /// Crea la marca del vehiculo.
        /// </summary>
        public ResponseAPI<VehicleBrand> CreateVehicleBrand(VehicleBrandPostDto vehicleBrandDto)
        {
            if (_vehicleBrandRepository.GetVehicleBrand(vehicleBrandDto.Name).Result != null)
            {
                _responseApi.StatusCode = HttpStatusCode.BadRequest;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add("El nombre de la marca del vehiculo ya existe");
                return _responseApi;
            }
            var vehicleBrand = _mapper.Map<VehicleBrand>(vehicleBrandDto);
            if (!_vehicleBrandRepository.CreateVehicleBrand(vehicleBrand).Result)
            {
                _responseApi.StatusCode = HttpStatusCode.InternalServerError;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add($"Algo salio mal guardando el registro {vehicleBrand.Name}");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.OK;
            _responseApi.IsSuccess = true;
            _responseApi.Result = vehicleBrand;
            return _responseApi;
        }

        /// <summary>
        /// Actualiza la marca del vehiculo.
        /// </summary>
        public ResponseAPI<VehicleBrand> PatchVehicleBrand(VehicleBrandPatchDto vehicleBrandDto)
        {
            var vehicleBrand = _mapper.Map<VehicleBrand>(vehicleBrandDto);
            if (!_vehicleBrandRepository.UpdateVehicleBrand(vehicleBrand).Result)
            {
                _responseApi.StatusCode = HttpStatusCode.InternalServerError;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add($"Algo salio mal guardando el registro {vehicleBrand.Name}");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.NoContent;
            _responseApi.IsSuccess = true;
            return _responseApi;
        }

        /// <summary>
        /// Elimnina la marca del vehiculo.
        /// </summary>
        public ResponseAPI<VehicleBrand> DeleteVehicleBrand(int vehicleBrandId)
        {
            var vehicleBrand = _vehicleBrandRepository.GetVehicleBrand(vehicleBrandId).Result;
            if (!_vehicleBrandRepository.DeleteVehicleBrand(vehicleBrand).Result)
            {
                _responseApi.StatusCode = HttpStatusCode.InternalServerError;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add($"Algo salio mal eliminando el registro {vehicleBrand.Name}");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.NoContent;
            _responseApi.IsSuccess = true;
            return _responseApi;
        }
    }
}
