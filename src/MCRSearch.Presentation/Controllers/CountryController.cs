using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.MCRSearch.Presentation.Dtos;
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

        /// <summary>
        /// Obtiene todos los paises.
        /// </summary>
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

        /// <summary>
        /// Obtiene el pais por ID.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id:int}", Name = "GetCountry")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCountry(int id)
        {
            var country = _countryService.GetCountry(id);
            if (country != null)
            {
                return Ok(country);
            }
            return NotFound();
        }

        /// <summary>
        /// Obtiene el pais por ID.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCountry(string name)
        {
            var country = _countryService.GetCountry(name);
            if (country != null)
            {
                return Ok(country);
            }
            return NotFound();
        }

        /// <summary>
        /// Crea el pais.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CountryDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateVehicleModel([FromBody] CountryPostDto countryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (countryDto == null)
            {
                return BadRequest(ModelState);
            }
            var responseApi = _countryService.CreateCountry(countryDto);
            if (responseApi.IsSuccess)
            {
                var country = responseApi.Result;
                return CreatedAtRoute("GetCountry", new { id = country.Id }, country);
            }
            return BadRequest(responseApi);
        }

        /// <summary>
        /// Actualiza el pais.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpPatch()]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PatchVehicleModel([FromBody] CountryPatchDto countryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var responseApi = _countryService.PatchCountry(countryDto);
            if (responseApi.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(responseApi);
        }

        /// <summary>
        /// Elimina el pais.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteVehicleModel(int id)
        {
            if (_countryService.GetCountry(id) == null)
            {
                return NotFound();
            }
            var responseApi = _countryService.DeleteCountry(id);
            if (responseApi.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(responseApi);
        }
    }
}
