using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
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
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetVehicleTypes()
        {
            var listVehicleTypes = _vehicleTypeService.GetVehicleTypes();
            if (listVehicleTypes.Count > 0)
            {
                return Ok(listVehicleTypes);
            }
            return NotFound();
        }
    }
}
