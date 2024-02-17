using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Presentation.Dtos;

namespace MCRSearch.src.MCRSearch.Application.Dtos
{
    public class AvailableVehicleDto
    {
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public CityDto PickUpCity { get; set; }
        public CityDto ReturnCity { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
