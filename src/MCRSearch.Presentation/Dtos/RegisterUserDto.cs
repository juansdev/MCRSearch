using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.MCRSearch.Presentation.Dtos
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public required string UserName { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "La clave es obligatorio")]
        public required string Password { get; set; }
        public required string Role { get; set; }
    }
}
