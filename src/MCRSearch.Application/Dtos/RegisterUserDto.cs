using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.MCRSearch.Application.Dtos
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "La clave es obligatorio")]
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
