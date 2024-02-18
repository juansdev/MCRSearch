using AutoMapper;
using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using MCRSearch.src.SharedDtos;
using System.Net;

namespace MCRSearch.src.MCRSearch.Application.Services
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly IMapper _mapper;
        private readonly ResponseAPI<VehicleType> _responseApi;
        public VehicleTypeService(IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
            _mapper = mapper;
            _responseApi = new ResponseAPI<VehicleType>();
        }

        /// <summary>
        /// Obtiene todos los tipos de vehiculos.
        /// </summary>
        public List<VehicleTypeDto> GetVehicleTypes()
        {
            var listVehicleTypesRepository = _vehicleTypeRepository.GetVehicleTypes().Result;
            var listVehicleTypesDto = new List<VehicleTypeDto>();
            foreach(var country in listVehicleTypesRepository)
            {
                listVehicleTypesDto.Add(_mapper.Map<VehicleTypeDto>(country));
            }
            return listVehicleTypesDto;
        }

        /// <summary>
        /// Obtiene el tipo de vehiculo por ID.
        /// </summary>
        public VehicleTypeDto GetVehicleType(int id)
        {
            var vehicleTypesRepository = _vehicleTypeRepository.GetVehicleType(id).Result;
            return _mapper.Map<VehicleTypeDto>(vehicleTypesRepository);
        }

        /// <summary>
        /// Obtiene el tipo de vehiculo por nombre.
        /// </summary>
        public VehicleTypeDto GetVehicleType(string name)
        {
            var vehicleTypesRepository = _vehicleTypeRepository.GetVehicleType(name).Result;
            return _mapper.Map<VehicleTypeDto>(vehicleTypesRepository);
        }

        /// <summary>
        /// Crea un tipo de vehiculo.
        /// </summary>
        public ResponseAPI<VehicleType> CreateVehicleType(VehicleTypePostDto vehicleTypeDto)
        {
            if(_vehicleTypeRepository.GetVehicleType(vehicleTypeDto.Name).Result != null)
            {
                _responseApi.StatusCode = HttpStatusCode.BadRequest;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add("El nombre del tipo de vehiculo ya existe");
                return _responseApi;
            }
            var vehicleType = _mapper.Map<VehicleType>(vehicleTypeDto);
            if (!_vehicleTypeRepository.CreateVehicleType(vehicleType).Result)
            {
                _responseApi.StatusCode = HttpStatusCode.InternalServerError;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add($"Algo salio mal guardado el registro {vehicleType.Name}");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.OK;
            _responseApi.IsSuccess = true;
            _responseApi.Result = vehicleType;
            return _responseApi;
        }

        /// <summary>
        /// Actualizar un tipo de vehiculo.
        /// </summary>
        public ResponseAPI<VehicleType> PatchVehicleType(VehicleTypePatchDto vehicleTypeDto)
        {
            var vehicleType = _mapper.Map<VehicleType>(vehicleTypeDto);
            if(!_vehicleTypeRepository.UpdateVehicleType(vehicleType).Result) { 
                _responseApi.StatusCode = HttpStatusCode.InternalServerError;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add($"Algo salio mal guardado del registro {vehicleType.Name}");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.NoContent;
            _responseApi.IsSuccess = true;
            return _responseApi;
        }

        /// <summary>
        /// Elimina un tipo de vehiculo.
        /// </summary>
        public ResponseAPI<VehicleType> DeleteVehicleType(int vehicleTypeId)
        {
            var vehicleModel = _vehicleTypeRepository.GetVehicleType(vehicleTypeId).Result;
            if(!_vehicleTypeRepository.DeleteVehicleType(vehicleModel).Result) { 
                _responseApi.StatusCode=HttpStatusCode.InternalServerError;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add($"Algo salio mal eliminando el registro {vehicleModel.Name}");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.NoContent;
            _responseApi.IsSuccess = true;
            return _responseApi;
        }
    }
}
