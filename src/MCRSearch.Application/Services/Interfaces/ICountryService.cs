﻿using MCRSearch.src.MCRSearch.Presentation.Dtos;

namespace MCRSearch.src.MCRSearch.Application.Services.Interfaces
{
    public interface ICountryService
    {
        public List<CountryDto> GetCountries();
    }
}