using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Presentation.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace MCRSearch.src.MCRSearch.Presentation.Controllers
{
    [Route("api/vehicleModel")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        private readonly IVehicleModelService _vehicleModelService;
        public VehicleModelController(IVehicleModelService vehicleModelService) {
            _vehicleModelService = vehicleModelService;
        }

        /// <summary>
        /// Obtiene todos los modelos de los vehiculos.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetVehicleModels()
        {
            var listVehicleModels = _vehicleModelService.GetVehicleModels();
            if (listVehicleModels.Count > 0)
            {
                return Ok(listVehicleModels);
            }
            return NotFound();
        }

        /// <summary>
        /// Obtiene el modelo del vehiculo por ID.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id:int}", Name = "GetVehicleModel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetVehicleModel(int id)
        {
            var vehicleModel = _vehicleModelService.GetVehicleModel(id);
            if (vehicleModel != null)
            {
                return Ok(vehicleModel);
            }
            return NotFound();
        }

        /// <summary>
        /// Obtiene el modelo del vehiculo por nombre.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetVehicleModel(string name)
        {
            var vehicleModel = _vehicleModelService.GetVehicleModel(name);
            if (vehicleModel != null)
            {
                return Ok(vehicleModel);
            }
            return NotFound();
        }

        /// <summary>
        /// Crea el modelo del vehiculo.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(VehicleModelDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateVehicleModel([FromBody] VehicleModelDto vehicleModelDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (vehicleModelDto == null)
            {
                return BadRequest(ModelState);
            }
            var responseApi = _vehicleModelService.CreateVehicleModel(vehicleModelDto);
            if (responseApi.IsSuccess)
            {
                var vehicleModel = responseApi.Result;
                return CreatedAtRoute("GetVehicleModel", new { id = vehicleModel.Id }, vehicleModel);
            }
            return BadRequest(responseApi);
        }

        /// <summary>
        /// Actualiza el modelo del vehiculo.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpPatch()]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PatchVehicleModel([FromBody] VehicleModelDto vehicleModelDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var responseApi = _vehicleModelService.PatchVehicleModel(vehicleModelDto);
            if (responseApi.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(responseApi);
        }

        /// <summary>
        /// Elimina el modelo del vehiculo.
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
            if (_vehicleModelService.GetVehicleModel(id) == null)
            {
                return NotFound();
            }
            var responseApi = _vehicleModelService.DeleteVehicleModel(id);
            if (responseApi.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(responseApi);
        }
    }
}
