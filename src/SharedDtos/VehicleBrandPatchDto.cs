using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.SharedDtos
{
    public class VehicleBrandPatchDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la marca del vehiculo es obligatorio")]
        public string? Name { get; set; }
    }
}
