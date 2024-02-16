using MCRSearch.src.MCRSearch.Core.Entities.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCRSearch.src.MCRSearch.Core.Entities
{
    public class Vehicle : BaseEntity
    {
        [ForeignKey("VehicleBrandId")]
        public int VehicleBrandId { get; set; }
        public VehicleBrand? VehicleBrand { get; set; }
        [ForeignKey("VehicleModelId")]
        public int VehicleModelId { get; set; }
        public VehicleModel? VehicleModel { get; set; }
        [ForeignKey("VehicleTypeId")]
        public int VehicleTypeId { get; set; }
        public VehicleType? VehicleType { get; set; }
    }
}
