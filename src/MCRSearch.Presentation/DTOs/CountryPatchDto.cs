using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.MCRSearch.Presentation.Dtos
{
    public class CountryPatchDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del pais obligatorio")]
        public string? Name { get; set; }
    }
}
