using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCRSearch.src.MCRSearch.Core.Entities
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        [ForeignKey("VehicleBrandId")]
        public int VehicleBrandId { get; set; }
        public required VehicleBrand VehicleBrand { get; set; }
        [ForeignKey("VehicleModelId")]
        public int VehicleModelId { get; set; }
        public required VehicleModel VehicleModel { get; set; }
        [ForeignKey("VehicleTypeId")]
        public int VehicleTypeId { get; set; }
        public required VehicleType VehicleType { get; set; }
    }
}
