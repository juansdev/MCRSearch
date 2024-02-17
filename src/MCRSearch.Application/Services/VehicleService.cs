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
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;
        private readonly ResponseAPI<Vehicle> _responseApi;
        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todos los vehiculos.
        /// </summary>
        public List<VehicleDto> GetVehicles()
        {
            var listVehiclesRepository = _vehicleRepository.GetVehicles().Result;
            var listVehiclesDto = new List<VehicleDto>();
            foreach(var country in listVehiclesRepository)
            {
                listVehiclesDto.Add(_mapper.Map<VehicleDto>(country));
            }
            return listVehiclesDto;
        }

        /// <summary>
        /// Obtiene el vehiculo por la ID.
        /// </summary>
        public VehicleDto GetVehicle(int id)
        {
            var vehiclesRepository = _vehicleRepository.GetVehicle(id).Result;
            return _mapper.Map<VehicleDto>(vehiclesRepository);
        }

        /// <summary>
        /// Obtiene el vehiculo segun el nombre del modelo, del tipo y de la marca.
        /// </summary>
        public VehicleDto GetVehicle(string modelName, string typeName, string brandName)
        {
            var vehiclesRepository = _vehicleRepository.GetVehicle(modelName, typeName, brandName).Result;
            return _mapper.Map<VehicleDto>(vehiclesRepository);
        }

        /// <summary>
        /// Obtiene el vehiculo por la ID del modelo, tipo y marca.
        /// </summary>
        public VehicleDto GetVehicle(int modelId, int typeId, int brandId)
        {
            var vehiclesRepository = _vehicleRepository.GetVehicle(modelId, typeId, brandId).Result;
            return _mapper.Map<VehicleDto>(vehiclesRepository);
        }

        /// <summary>
        /// Obtiene los vehiculos segun el modelo.
        /// </summary>
        public List<VehicleDto> GetVehiclesInModel(int modelId)
        {
            var listVehiclesRepository = _vehicleRepository.GetVehiclesInModel(modelId).Result;
            var listVehiclesDto = new List<VehicleDto>();
            foreach (var country in listVehiclesRepository)
            {
                listVehiclesDto.Add(_mapper.Map<VehicleDto>(country));
            }
            return listVehiclesDto;
        }

        /// <summary>
        /// Obtiene los vehiculos segun el tipo.
        /// </summary>
        public List<VehicleDto> GetVehiclesInType(int typeId)
        {
            var listVehiclesRepository = _vehicleRepository.GetVehiclesInType(typeId).Result;
            var listVehiclesDto = new List<VehicleDto>();
            foreach (var country in listVehiclesRepository)
            {
                listVehiclesDto.Add(_mapper.Map<VehicleDto>(country));
            }
            return listVehiclesDto;
        }

        /// <summary>
        /// Obtiene los vehiculos segun la marca.
        /// </summary>
        public List<VehicleDto> GetVehiclesInBrand(int brandId)
        {
            var listVehiclesRepository = _vehicleRepository.GetVehiclesInBrand(brandId).Result;
            var listVehiclesDto = new List<VehicleDto>();
            foreach (var country in listVehiclesRepository)
            {
                listVehiclesDto.Add(_mapper.Map<VehicleDto>(country));
            }
            return listVehiclesDto;
        }

        /// <summary>
        /// Crea un vehiculo.
        /// </summary>
        public ResponseAPI<Vehicle> CreateVehicle(VehicleDto vehicleDto)
        {
            if (_vehicleRepository.GetVehicle(vehicleDto.VehicleModelId, vehicleDto.VehicleTypeId, vehicleDto.VehicleBrandId).Result != null)
            {
                _responseApi.StatusCode = HttpStatusCode.BadRequest;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add("Un vehiculo con ese modelo, tipo y marca, ya existe");
                return _responseApi;
            }
            var vehicle = _mapper.Map<Vehicle>(vehicleDto);
            if (!_vehicleRepository.CreateVehicle(vehicle).Result)
            {
                _responseApi.StatusCode = HttpStatusCode.InternalServerError;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add($"Algo salio mal guardando el registro.");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.OK;
            _responseApi.IsSuccess = true;
            _responseApi.Result = vehicle;
            return _responseApi;
        }

        /// <summary>
        /// Actualiza el vehiculo.
        /// </summary>
        public ResponseAPI<Vehicle> PatchVehicle(VehicleDto vehicleDto)
        {
            var vehicle = _mapper.Map<Vehicle>(vehicleDto);
            if (!_vehicleRepository.UpdateVehicle(vehicle).Result)
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
        /// Elimina el vehiculo.
        /// </summary>
        public ResponseAPI<Vehicle> DeleteVehicle(int vehicleId)
        {
            var vehicle = _vehicleRepository.GetVehicle(vehicleId).Result;
            if (!_vehicleRepository.DeleteVehicle(vehicle).Result)
            {
                _responseApi.StatusCode = HttpStatusCode.InternalServerError;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add($"Algo salio mal eliminando el registro");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.NoContent;
            _responseApi.IsSuccess = true;
            return _responseApi;
        }


    }
}
