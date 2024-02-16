using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
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
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetVehicleBrands()
        {
            var listVehicleBrands= _vehicleBrandService.GetVehicleBrands();
            if (listVehicleBrands.Count > 0)
            {
                return Ok(listVehicleBrands);
            }
            return NotFound();
        }
    }
}
