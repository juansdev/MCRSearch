using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.MCRSearch.Presentation.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiMovies.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _userService;

        public AppUserController(IAppUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Obtiene todos los usuarios, solo habilitado para el rol Admin.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetUsers()
        {
            var listUsers = _userService.GetUsers();
            return Ok(listUsers);
        }

        /// <summary>
        /// Obtiene el usuario por ID, solo habilitado para el rol Admin.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUser(string id)
        {
            var itemUser = _userService.GetUser(id);
            if (itemUser == null)
            {
                return NotFound();
            }
            return Ok(itemUser);
        }

        /// <summary>
        /// Registra el usuario en la BD.
        /// </summary>
        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Register([FromBody] AppUserRegisterDto registerUserDto)
        {
            var responseApi = _userService.Register(registerUserDto);
            if (responseApi.IsSuccess)
            {
                return Ok(responseApi);
            }
            return BadRequest(responseApi);
        }

        /// <summary>
        /// Obtiene el JWT Bearer para la autentificacion.
        /// </summary>
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Login([FromBody] AppUserLoginDto loginUserDto)
        {
            var responseApi = _userService.Login(loginUserDto);
            if (responseApi.IsSuccess)
            {
                return Ok(responseApi);
            }
            return BadRequest(responseApi);
        }
    }
}
