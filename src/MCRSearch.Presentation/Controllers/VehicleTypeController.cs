using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.SharedDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MCRSearch.src.MCRSearch.Presentation.Controllers
{
    [Route("api/vehicleType")]
    [ApiController]
    public class VehicleTypeController : ControllerBase
    {
        private readonly IVehicleTypeService _vehicleTypeService;
        public VehicleTypeController(IVehicleTypeService vehicleTypeService) {
            _vehicleTypeService = vehicleTypeService;
        }

        /// <summary>
        /// Obtiene todos los tipos de los vehiculos.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<VehicleTypeDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetVehicleTypes()
        {
            var listVehicleTypes = _vehicleTypeService.GetVehicleTypes();
            if (listVehicleTypes.Count > 0)
            {
                return Ok(listVehicleTypes);
            }
            return NotFound();
        }

        /// <summary>
        /// Obtiene el tipo de vehiculo por ID.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id:int}", Name = "GetVehicleType")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VehicleTypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetVehicleType(int id)
        {
            var vehicleType = _vehicleTypeService.GetVehicleType(id);
            if (vehicleType != null)
            {
                return Ok(vehicleType);
            }
            return NotFound();
        }

        /// <summary>
        /// Obtiene el tipo de vehiculo por nombre.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VehicleTypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetVehicleType(string name)
        {
            var vehicleType = _vehicleTypeService.GetVehicleType(name);
            if (vehicleType != null)
            {
                return Ok(vehicleType);
            }
            return NotFound();
        }
        /// <summary>
        /// Crea el tipo de vehiculo.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(VehicleTypeDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateVehicleType([FromBody] VehicleTypePostDto vehicleTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (vehicleTypeDto == null)
            {
                return BadRequest(ModelState);
            }
            var responseApi = _vehicleTypeService.CreateVehicleType(vehicleTypeDto);
            if (responseApi.IsSuccess)
            {
                var vehicleType = responseApi.Result;
                return CreatedAtRoute("GetVehicleType", new { id = vehicleType.Id }, vehicleType);
            }
            return BadRequest(responseApi);
        }

        /// <summary>
        /// Actualiza el tipo de vehiculo.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PatchVehicleType([FromBody] VehicleTypePatchDto vehicleTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var responseApi = _vehicleTypeService.PatchVehicleType(vehicleTypeDto);
            if (responseApi.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(responseApi);
        }

        /// <summary>
        /// Elimina el tipo de vehiculo.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteVehicleType(int id)
        {
            if (_vehicleTypeService.GetVehicleType(id) == null)
            {
                return NotFound();
            }
            var responseApi = _vehicleTypeService.DeleteVehicleType(id);
            if (responseApi.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(responseApi);
        }
    }
}
