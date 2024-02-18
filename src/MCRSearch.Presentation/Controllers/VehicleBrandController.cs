using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.SharedDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MCRSearch.src.MCRSearch.Presentation.Controllers
{
    [Route("api/vehicleBrand")]
    [ApiController]
    public class VehicleBrandController : ControllerBase
    {
        private readonly IVehicleBrandService _vehicleBrandService;
        public VehicleBrandController(IVehicleBrandService vehicleBrandService) {
            _vehicleBrandService = vehicleBrandService;
        }

        /// <summary>
        /// Obtiene todos las marcas de los vehiculos.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<VehicleBrandDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetVehicleBrands()
        {
            var listVehicleBrands= _vehicleBrandService.GetVehicleBrands();
            if (listVehicleBrands.Count > 0)
            {
                return Ok(listVehicleBrands);
            }
            return NotFound();
        }

        /// <summary>
        /// Obtiene la marca del vehiculo por ID.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id:int}", Name = "GetVehicleBrand")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VehicleBrandDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetVehicleBrand(int id)
        {
            var vehicleBrand = _vehicleBrandService.GetVehicleBrand(id);
            if (vehicleBrand != null)
            {
                return Ok(vehicleBrand);
            }
            return NotFound();
        }

        /// <summary>
        /// Obtiene la marca del vehiculo por nombre.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VehicleBrandDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetVehicleBrand(string name)
        {
            var vehicleBrand = _vehicleBrandService.GetVehicleBrand(name);
            if (vehicleBrand != null)
            {
                return Ok(vehicleBrand);
            }
            return NotFound();
        }

        /// <summary>
        /// Crea la marca del vehiculo.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(VehicleBrandDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateVehicleBrand([FromBody] VehicleBrandPostDto vehicleBrandDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (vehicleBrandDto == null)
            {
                return BadRequest(ModelState);
            }
            var responseApi = _vehicleBrandService.CreateVehicleBrand(vehicleBrandDto);
            if (responseApi.IsSuccess)
            {
                var vehicleBrand = responseApi.Result;
                return CreatedAtRoute("GetVehicleBrand", new { id = vehicleBrand.Id }, vehicleBrand);
            }
            return BadRequest(responseApi);
        }

        /// <summary>
        /// Actualiza la marca del vehiculo.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PatchVehicleBrand([FromBody] VehicleBrandPatchDto vehicleBrandDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var responseApi = _vehicleBrandService.PatchVehicleBrand(vehicleBrandDto);
            if (responseApi.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(responseApi);
        }

        /// <summary>
        /// Elimina la marca del vehiculo.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteVehicleBrand(int id)
        {
            if (_vehicleBrandService.GetVehicleBrand(id) == null)
            {
                return NotFound();
            }
            var responseApi = _vehicleBrandService.DeleteVehicleBrand(id);
            if (responseApi.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(responseApi);
        }
    }
}
