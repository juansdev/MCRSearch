using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.MCRSearch.Application.Dtos
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "La clave es obligatorio")]
        public string? Password { get; set; }
    }
}
