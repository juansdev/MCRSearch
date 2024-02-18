using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.SharedDtos
{
    public class AvailableVehiclePatchDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El vehiculo asociado es obligatorio")]
        public int VehicleId { get; set; }
        [Required(ErrorMessage = "La ciudad de recogida asociado es obligatorio")]
        public int PickUpCityId { get; set; }
        [Required(ErrorMessage = "La ciudad de retorno asociado es obligatorio")]
        public int ReturnCityId { get; set; }
    }
}
