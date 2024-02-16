using AutoMapper;
using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using MCRSearch.src.MCRSearch.Presentation.Dtos;

namespace MCRSearch.src.MCRSearch.Application.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IVehicleModelRepository _vehicleModelRepository;
        private readonly IMapper _mapper;
        public VehicleModelService(IVehicleModelRepository vehicleModelRepository, IMapper mapper)
        {
            _vehicleModelRepository = vehicleModelRepository;
            _mapper = mapper;
        }
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
    }
}
