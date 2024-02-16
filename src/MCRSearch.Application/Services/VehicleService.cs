using AutoMapper;
using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using MCRSearch.src.MCRSearch.Presentation.Dtos;

namespace MCRSearch.src.MCRSearch.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;
        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }
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
    }
}
