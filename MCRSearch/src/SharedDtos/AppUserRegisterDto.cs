using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.SharedDtos
{
    public class AppUserRegisterDto
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "La clave es obligatorio")]
        public string? Password { get; set; }
    }
}
