using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.MCRSearch.Presentation.Dtos
{
    public class VehicleModelPatchDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del modelo del vehiculo obligatorio")]
        public string? Name { get; set; }
    }
}
