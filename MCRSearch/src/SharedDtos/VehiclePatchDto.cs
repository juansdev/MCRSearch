using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.SharedDtos
{
    public class VehiclePatchDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La marca del vehiculo asociado es obligatorio")]
        public int VehicleBrandId { get; set; }
        [Required(ErrorMessage = "El modelo del vehiculo asociado es obligatorio")]
        public int VehicleModelId { get; set; }
        [Required(ErrorMessage = "El tipo de vehiculo asociado es obligatorio")]
        public int VehicleTypeId { get; set; }
    }
}
