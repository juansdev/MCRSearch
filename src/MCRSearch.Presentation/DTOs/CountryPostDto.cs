using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.MCRSearch.Presentation.Dtos
{
    public class CountryPostDto
    {
        [Required(ErrorMessage = "El nombre del pais es obligatorio")]
        public string? Name { get; set; }
    }
}
