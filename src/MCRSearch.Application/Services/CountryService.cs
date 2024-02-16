using AutoMapper;
using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using MCRSearch.src.MCRSearch.Presentation.Dtos;

namespace MCRSearch.src.MCRSearch.Application.Services
{
    public class CountryService: ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
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
    }
}
