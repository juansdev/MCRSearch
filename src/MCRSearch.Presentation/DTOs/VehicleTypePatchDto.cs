using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.MCRSearch.Presentation.Dtos
{
    public class VehicleTypePatchDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del tipo del vehiculo es obligatorio")]
        public string? Name { get; set; }
    }
}
