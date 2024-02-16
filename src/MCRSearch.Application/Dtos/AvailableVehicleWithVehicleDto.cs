using MCRSearch.src.MCRSearch.Core.Entities;

namespace MCRSearch.src.MCRSearch.Application.Dtos
{
    public class AvailableVehicleWithVehicleDto
    {
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
