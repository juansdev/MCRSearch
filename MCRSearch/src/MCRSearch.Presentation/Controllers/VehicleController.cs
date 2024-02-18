using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.SharedDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MCRSearch.src.MCRSearch.Presentation.Controllers
{
    [Route("api/vehicle")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService) {
            _vehicleService = vehicleService;
        }

        /// <summary>
        /// Obtiene todos los vehiculos.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<VehicleDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetVehicles()
        {
            var listVehicles = _vehicleService.GetVehicles();
            if (listVehicles.Count > 0)
            {
                return Ok(listVehicles);
            }
            return NotFound();
        }

        /// <summary>
        /// Obtiene el vehiculo por ID.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id:int}", Name = "GetVehicle")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VehicleDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetVehicle(int id)
        {
            var vehicle = _vehicleService.GetVehicle(id);
            if (vehicle != null)
            {
                return Ok(vehicle);
            }
            return NotFound();
        }

        /// <summary>
        /// Obtiene el vehiculo por el nombre del modelo, tipo y marca.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{modelName}/{typeName}/{brandName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VehicleDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetVehicle(string modelName, string typeName, string brandName)
        {
            var vehicle = _vehicleService.GetVehicle(modelName, typeName, brandName);
            if (vehicle != null)
            {
                return Ok(vehicle);
            }
            return NotFound();
        }

        /// <summary>
        /// Obtiene el vehiculo por la ID del modelo, tipo y marca.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{modelId:int}/{typeId:int}/{brandId:int}")]
        [ProducesResponseType(201, Type = typeof(VehicleDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetVehicle(int modelId, int typeId, int brandId)
        {
            var vehicle = _vehicleService.GetVehicle(modelId, typeId, brandId);
            if (vehicle != null)
            {
                return Ok(vehicle);
            }
            return NotFound();
        }

        /// <summary>
        /// Obtiene los vehiculos segun el modelo.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("model/{modelId:int}")]
        [ProducesResponseType(200, Type = typeof(List<VehicleDto>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetVehiclesInModel(int modelId)
        {
            var listVehicles = _vehicleService.GetVehiclesInModel(modelId);
            if (listVehicles.Count > 0)
            {
                return Ok(listVehicles);
            }
            return NotFound();
        }

        /// <summary>
        /// Obtiene los vehiculos segun el tipo.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("type/{typeId:int}")]
        [ProducesResponseType(200, Type = typeof(List<VehicleDto>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetVehiclesInType(int typeId)
        {
            var listVehicles = _vehicleService.GetVehiclesInType(typeId);
            if (listVehicles.Count > 0)
            {
                return Ok(listVehicles);
            }
            return NotFound();
        }

        /// <summary>
        /// Obtiene los vehiculos segun la marca.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("brand/{brandId:int}")]
        [ProducesResponseType(200, Type = typeof(List<VehicleDto>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetVehiclesInBrand(int brandId)
        {
            var listVehicles = _vehicleService.GetVehiclesInBrand(brandId);
            if (listVehicles.Count > 0)
            {
                return Ok(listVehicles);
            }
            return NotFound();
        }

        /// <summary>
        /// Crea el vehiculo.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateVehicle([FromBody] VehiclePostDto vehicleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (vehicleDto == null)
            {
                return BadRequest(ModelState);
            }
            var responseApi = _vehicleService.CreateVehicle(vehicleDto);
            if (responseApi.IsSuccess)
            {
                var vehicle = responseApi.Result;
                return CreatedAtRoute("GetVehicle", new { id = vehicle.Id }, vehicle);
            }
            return BadRequest(responseApi);
        }

        /// <summary>
        /// Actualiza el vehiculo.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PatchVehicle([FromBody] VehiclePatchDto vehicleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var responseApi = _vehicleService.PatchVehicle(vehicleDto);
            if (responseApi.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(responseApi);
        }

        /// <summary>
        /// Elimina el vehiculo.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteVehicleModel(int id)
        {
            if (_vehicleService.GetVehicle(id) == null)
            {
                return NotFound();
            }
            var responseApi = _vehicleService.DeleteVehicle(id);
            if (responseApi.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(responseApi);
        }
    }
}
