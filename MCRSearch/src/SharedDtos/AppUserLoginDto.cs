using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.SharedDtos
{
    public class AppUserLoginDto
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "La clave es obligatorio")]
        public string? Password { get; set; }
    }
}
