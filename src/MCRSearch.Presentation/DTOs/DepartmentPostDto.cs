using MCRSearch.src.MCRSearch.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.MCRSearch.Presentation.Dtos
{
    public class DepartmentPostDto
    {
        [Required(ErrorMessage = "El nombre del departamento es obligatorio")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "El pais asociado es obligatorio")]
        public int CountryId { get; set; }
    }
}
