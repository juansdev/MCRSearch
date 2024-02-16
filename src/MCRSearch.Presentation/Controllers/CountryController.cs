using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MCRSearch.src.MCRSearch.Presentation.Controllers
{
    [Route("api/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService) {
            _countryService = countryService;
        }
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCountries()
        {
            var listCountries = _countryService.GetCountries();
            if (listCountries.Count > 0)
            {
                return Ok(listCountries);
            }
            return NotFound();
        }
    }
}
