﻿using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.SharedDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MCRSearch.src.MCRSearch.Presentation.Controllers
{
    [Route("api/availableVehicle")]
    [ApiController]
    public class AvailableVehicleController : ControllerBase
    {
        private readonly IAvailableVehicleService _availableVehicleService;
        public AvailableVehicleController(IAvailableVehicleService availableVehicleService) {
            _availableVehicleService = availableVehicleService;
        }

        /// <summary>
        /// Obtiene todos los vehiculos disponibles segun localidad del cliente, localidad de recogida y de regreso.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{localizedCustomerCountryName}/{pickUpCityName}/{returnCityName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AvailableVehicleDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAvailableVehicles(string localizedCustomerCountryName, string pickUpCityName, string returnCityName)
        {
            var isEnabledMarked = _availableVehicleService.IsEnabledMarket(localizedCustomerCountryName, pickUpCityName);
            if (isEnabledMarked)
            {
                var listAvailableVehicles = _availableVehicleService.GetAvailableVehicles(pickUpCityName, returnCityName);
                if (listAvailableVehicles.Count == 0)
                {
                    return NotFound();
                }
                return Ok(listAvailableVehicles);
            }
            return NotFound();
        }

        /// <summary>
        /// Obtiene todos los vehiculos disponibles segun localidad del cliente, localidad de recogida y de regreso.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{localizedCustomerCountryId:int}/{pickUpCityId:int}/{returnCityId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AvailableVehicleDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAvailableVehicles(int localizedCustomerCountryId, int pickUpCityId, int returnCityId)
        {
            var isEnabledMarked = _availableVehicleService.IsEnabledMarket(localizedCustomerCountryId, pickUpCityId);
            if (isEnabledMarked)
            {
                var listAvailableVehicles = _availableVehicleService.GetAvailableVehicles(pickUpCityId, returnCityId);
                if (listAvailableVehicles.Count == 0)
                {
                    return NotFound();
                }
                return Ok(listAvailableVehicles);
            }
            return NotFound();
        }

        /// <summary>
        /// Obtiene el vehiculo disponible por ID.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id:int}", Name = "GetAvailableVehicle")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AvailableVehicleDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAvailableVehicle(int id)
        {
            var availableVehicle = _availableVehicleService.GetAvailableVehicle(id);
            if (availableVehicle == null)
            {
                return NotFound();
            }
            return Ok(availableVehicle);
        }

        /// <summary>
        /// Obtiene todos los vehiculos disponibles segun el vehiculo.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("vehicle/{vehicleId:int}")]
        [ProducesResponseType(200, Type = typeof(List<AvailableVehicleDto>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAvailableVehiclesInVehicle(int vehicleId)
        {
            var listAvailableVehicles = _availableVehicleService.GetAvailableVehiclesInVehicle(vehicleId);
            if (listAvailableVehicles.Count == 0)
            {
                return NotFound();
            }
            return Ok(listAvailableVehicles);
        }

        /// <summary>
        /// Obtiene todos los vehiculos disponibles segun la ciudad.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("city/{cityId:int}")]
        [ProducesResponseType(200, Type = typeof(List<AvailableVehicleDto>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAvailableVehiclesInCity(int cityId)
        {
            var listAvailableVehicles = _availableVehicleService.GetAvailableVehiclesInCity(cityId);
            if (listAvailableVehicles.Count == 0)
            {
                return NotFound();
            }
            return Ok(listAvailableVehicles);
        }

        /// <summary>
        /// Agrega un vehiculo a la disponibilidad.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateAvailableVehicle([FromBody] AvailableVehiclePostDto availableVehicleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (availableVehicleDto == null)
            {
                return BadRequest(ModelState);
            }
            var responseApi = _availableVehicleService.CreateAvailableVehicle(availableVehicleDto);
            if (responseApi.IsSuccess)
            {
                var availableVehicle = responseApi.Result;
                return CreatedAtRoute("GetAvailableVehicle", new { id = availableVehicle.Id }, availableVehicle);
            }
            return BadRequest(responseApi);
        }

        /// <summary>
        /// Actualiza la disponibilidad de un vehiculo.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PatchVehicleModel([FromBody] AvailableVehiclePatchDto availableVehicleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var responseApi = _availableVehicleService.PatchAvailableVehicle(availableVehicleDto);
            if (responseApi.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(responseApi);
        }

        /// <summary>
        /// Elimina la disponibilidad de un vehiculo.
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
            if (_availableVehicleService.GetAvailableVehicle(id) == null)
            {
                return NotFound();
            }
            var responseApi = _availableVehicleService.DeleteAvailableVehicle(id);
            if (responseApi.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(responseApi);
        }
    }
}
