using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.SharedDtos
{
    public class CityPatchDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la ciudad es obligatorio")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "El departamento asociado es obligatorio")]
        public int DepartmentId { get; set; }
    }
}
