using AutoMapper;
using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using MCRSearch.src.MCRSearch.Presentation.Dtos;

namespace MCRSearch.src.MCRSearch.Application.Services
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly IMapper _mapper;
        public VehicleTypeService(IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
            _mapper = mapper;
        }
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
    }
}
