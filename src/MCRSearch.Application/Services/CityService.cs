using AutoMapper;
using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using MCRSearch.src.MCRSearch.Presentation.Dtos;

namespace MCRSearch.src.MCRSearch.Application.Services
{
    public class CityService: ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
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
    }
}
