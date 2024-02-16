﻿using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
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
        [AllowAnonymous]
        [HttpGet("{localizedCustomerCountryId:int}/{pickUpCityId:int}/{returnCityId:int}", Name = "GetAvailableVehicles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [AllowAnonymous]
        [HttpGet("{vehicleId:int}", Name = "GetAvailableVehiclesInVehicle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAvailableVehiclesInVehicle(int vehicleId)
        {
            var listAvailableVehicles = _availableVehicleService.GetAvailableVehiclesInVehicle(vehicleId);
            if (listAvailableVehicles.Count == 0)
            {
                return NotFound();
            }
            return Ok(listAvailableVehicles);
        }
        [AllowAnonymous]
        [HttpGet("city/{cityId:int}", Name = "GetAvailableVehiclesInCity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAvailableVehiclesInCity(int cityId)
        {
            var listAvailableVehicles = _availableVehicleService.GetAvailableVehiclesInCity(cityId);
            if (listAvailableVehicles.Count == 0)
            {
                return NotFound();
            }
            return Ok(listAvailableVehicles);
        }
    }
}
