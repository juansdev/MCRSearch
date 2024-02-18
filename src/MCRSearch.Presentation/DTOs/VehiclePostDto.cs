using MCRSearch.src.MCRSearch.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.MCRSearch.Presentation.Dtos
{
    public class VehiclePostDto
    {
        [Required(ErrorMessage = "La marca del vehiculo asociado es obligatorio")]
        public int VehicleBrandId { get; set; }
        [Required(ErrorMessage = "El modelo del vehiculo asociado es obligatorio")]
        public int VehicleModelId { get; set; }
        [Required(ErrorMessage = "El tipo del vehiculo asociado es obligatorio")]
        public int VehicleTypeId { get; set; }
    }
}
