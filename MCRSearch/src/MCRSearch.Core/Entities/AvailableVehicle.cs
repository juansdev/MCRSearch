using MCRSearch.src.MCRSearch.Core.Entities.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCRSearch.src.MCRSearch.Core.Entities
{
    public class AvailableVehicle: BaseEntity
    {
        [ForeignKey("VehicleId")]
        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
        [ForeignKey("PickUpCityId")]
        public int PickUpCityId { get; set; }
        [ForeignKey("ReturnCityId")]
        public int ReturnCityId { get; set; }
        public City? ReturnCity { get; set; }
        public City? PickUpCity { get; set; }
    }
}
