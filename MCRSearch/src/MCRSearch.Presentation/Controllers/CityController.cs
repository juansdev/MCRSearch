using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.SharedDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MCRSearch.src.MCRSearch.Presentation.Controllers
{
    [Route("api/city")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService) {
            _cityService = cityService;
        }

        /// <summary>
        /// Obtiene todas las ciudades.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CityDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCities()
        {
            var listCities = _cityService.GetCities();
            if (listCities.Count > 0)
            {
                return Ok(listCities);
            }
            return NotFound();
        }

        /// <summary>
        /// Obtiene la ciudad por ID.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id:int}", Name = "GetCity")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CityDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCity(int id)
        {
            var city = _cityService.GetCity(id);
            if (city != null)
            {
                return Ok(city);
            }
            return NotFound();
        }

        /// <summary>
        /// Obtiene la ciudad por nombre.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CityDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCity(string name)
        {
            var city = _cityService.GetCity(name);
            if (city != null)
            {
                return Ok(city);
            }
            return NotFound();
        }
        
        /// <summary>
        /// Crea la ciudad.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CityDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateCity([FromBody] CityPostDto cityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (cityDto == null)
            {
                return BadRequest(ModelState);
            }
            var responseApi = _cityService.CreateCity(cityDto);
            if (responseApi.IsSuccess)
            {
                var city = responseApi.Result;
                return CreatedAtRoute("GetCity", new { id = city.Id }, city);
            }
            return BadRequest(responseApi);
        }

        /// <summary>
        /// Actualiza la ciudad.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PatchCity([FromBody] CityPatchDto cityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var responseApi = _cityService.PatchCity(cityDto);
            if (responseApi.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(responseApi);
        }

        /// <summary>
        /// Elimina la ciudad.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCity(int id)
        {
            if (_cityService.GetCity(id) == null)
            {
                return NotFound();
            }
            var responseApi = _cityService.DeleteCity(id);
            if (responseApi.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(responseApi);
        }
    }
}
