using AutoMapper;
using MCRSearch.src.MCRSearch.Application.Dtos;
using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using MCRSearch.src.MCRSearch.Presentation.Dtos;
using System.Net;

namespace MCRSearch.src.MCRSearch.Application.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IVehicleModelRepository _vehicleModelRepository;
        private readonly IMapper _mapper;
        protected ResponseAPI<VehicleModel> _responseApi;
        public VehicleModelService(IVehicleModelRepository vehicleModelRepository, IMapper mapper)
        {
            _vehicleModelRepository = vehicleModelRepository;
            _mapper = mapper;
            _responseApi = new ResponseAPI<VehicleModel>();
        }

        /// <summary>
        /// Obtiene todos los modelos de vehiculos.
        /// </summary>
        public List<VehicleModelDto> GetVehicleModels()
        {
            var listVehicleModelsRepository = _vehicleModelRepository.GetVehicleModels().Result;
            var listVehicleModelsDto = new List<VehicleModelDto>();
            foreach(var country in listVehicleModelsRepository)
            {
                listVehicleModelsDto.Add(_mapper.Map<VehicleModelDto>(country));
            }
            return listVehicleModelsDto;
        }

        /// <summary>
        /// Obtiene el modelo del vehiculo por ID.
        /// </summary>
        public VehicleModelDto GetVehicleModel(int vehicleModelId)
        {
            var vehicleModelRepository = _vehicleModelRepository.GetVehicleModel(vehicleModelId).Result;
            return _mapper.Map<VehicleModelDto>(vehicleModelRepository);
        }

        /// <summary>
        /// Obtiene el modelo del vehiculo por Nombre.
        /// </summary>
        public VehicleModelDto GetVehicleModel(string vehicleModelName)
        {
            var vehicleModelRepository = _vehicleModelRepository.GetVehicleModel(vehicleModelName).Result;
            return _mapper.Map<VehicleModelDto>(vehicleModelRepository);
        }

        /// <summary>
        /// Crea el modelo del vehiculo.
        /// </summary>
        public ResponseAPI<VehicleModel> CreateVehicleModel(VehicleModelDto vehicleModelDto)
        {
            if (_vehicleModelRepository.GetVehicleModel(vehicleModelDto.Name).Result != null)
            {
                _responseApi.StatusCode = HttpStatusCode.BadRequest;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add("El nombre del modelo del vehiculo ya existe");
                return _responseApi;
            }
            var vehicleModel = _mapper.Map<VehicleModel>(vehicleModelDto);
            if (!_vehicleModelRepository.CreateVehicleModel(vehicleModel).Result)
            {
                _responseApi.StatusCode = HttpStatusCode.InternalServerError;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add($"Algo salio mal guardando el registro {vehicleModel.Name}");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.OK;
            _responseApi.IsSuccess = true;
            _responseApi.Result = vehicleModel;
            return _responseApi;
        }

        /// <summary>
        /// Actualiza el modelo del vehiculo.
        /// </summary>
        public ResponseAPI<VehicleModel> PatchVehicleModel(VehicleModelDto vehicleModelDto)
        {
            var vehicleModel = _mapper.Map<VehicleModel>(vehicleModelDto);
            if (!_vehicleModelRepository.UpdateVehicleModel(vehicleModel).Result)
            {
                _responseApi.StatusCode = HttpStatusCode.InternalServerError;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add($"Algo salio mal guardando el registro {vehicleModel.Name}");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.NoContent;
            _responseApi.IsSuccess = true;
            return _responseApi;
        }

        /// <summary>
        /// Elimnina el modelo del vehiculo.
        /// </summary>
        public ResponseAPI<VehicleModel> DeleteVehicleModel(int vehicleModelId)
        {
            var vehicleModel = _vehicleModelRepository.GetVehicleModel(vehicleModelId).Result;
            if (!_vehicleModelRepository.DeleteVehicleModel(vehicleModel).Result)
            {
                _responseApi.StatusCode = HttpStatusCode.InternalServerError;
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
