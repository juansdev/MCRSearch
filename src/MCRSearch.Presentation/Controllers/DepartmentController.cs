using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MCRSearch.src.MCRSearch.Presentation.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService) {
            _departmentService = departmentService;
        }
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetDepartments()
        {
            var listDepartments = _departmentService.GetDepartments();
            if (listDepartments.Count > 0)
            {
                return Ok(listDepartments);
            }
            return NotFound();
        }
    }
}
