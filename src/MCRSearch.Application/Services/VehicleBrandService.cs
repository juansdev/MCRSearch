using AutoMapper;
using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using MCRSearch.src.MCRSearch.Presentation.Dtos;

namespace MCRSearch.src.MCRSearch.Application.Services
{
    public class VehicleBrandService: IVehicleBrandService
    {
        private readonly IVehicleBrandRepository _vehicleBrandRepository;
        private readonly IMapper _mapper;
        public VehicleBrandService(IVehicleBrandRepository vehicleBrandRepository, IMapper mapper)
        {
            _vehicleBrandRepository = vehicleBrandRepository;
            _mapper = mapper;
        }
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
    }
}
