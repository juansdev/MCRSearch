using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCRSearch.src.MCRSearch.Core.Entities
{
    public class AvailableVehicle
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        [ForeignKey("VehicleId")]
        public int VehicleId { get; set; }
        public required Vehicle Vehicle { get; set; }
        [ForeignKey("CityId")]
        public int CityId { get; set; }
        public required City City { get; set; }
    }
}
