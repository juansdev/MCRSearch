using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.SharedDtos
{
    public class VehicleBrandPostDto
    {
        [Required(ErrorMessage = "El nombre de la marca del vehiculo es obligatorio")]
        public string? Name { get; set; }
    }
}
