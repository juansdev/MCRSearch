using MCRSearch.src.MCRSearch.Application.Services;
using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.MCRSearch.Presentation.Dtos;
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

        /// <summary>
        /// Obtiene todos los departamentos.
        /// </summary>
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

        /// <summary>
        /// Obtiene el departamento por ID.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id:int}", Name = "GetDepartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetDepartment(int id)
        {
            var department = _departmentService.GetDepartment(id);
            if (department != null)
            {
                return Ok(department);
            }
            return NotFound();
        }

        /// <summary>
        /// Obtiene el departamento por nombre.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetDepartment(string name)
        {
            var department = _departmentService.GetDepartment(name);
            if (department != null)
            {
                return Ok(department);
            }
            return NotFound();
        }

        /// <summary>
        /// Crea el departamento.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(DepartmentDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateDepartment([FromBody] DepartmentDto departmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (departmentDto == null)
            {
                return BadRequest(ModelState);
            }
            var responseApi = _departmentService.CreateDepartment(departmentDto);
            if (responseApi.IsSuccess)
            {
                var department = responseApi.Result;
                return CreatedAtRoute("GetDepartment", new { id = department.Id }, department);
            }
            return BadRequest(responseApi);
        }

        /// <summary>
        /// Actualiza el departamento.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpPatch()]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PatchDepartment([FromBody] DepartmentDto departmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var responseApi = _departmentService.PatchDepartment(departmentDto);
            if (responseApi.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(responseApi);
        }

        /// <summary>
        /// Elimina el departamento.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteDepartment(int id)
        {
            if (_departmentService.GetDepartment(id) == null)
            {
                return NotFound();
            }
            var responseApi = _departmentService.DeleteDepartment(id);
            if (responseApi.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(responseApi);
        }
    }
}
