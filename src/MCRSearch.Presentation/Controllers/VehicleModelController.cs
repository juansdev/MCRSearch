using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetVehicleModels()
        {
            var listVehicleModals = _vehicleModelService.GetVehicleModels();
            if (listVehicleModals.Count > 0)
            {
                return Ok(listVehicleModals);
            }
            return NotFound();
        }
    }
}
