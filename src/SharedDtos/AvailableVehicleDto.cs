using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Presentation.DTOs.Commons;

namespace MCRSearch.src.SharedDtos
{
    public class AvailableVehicleDto : BaseDto
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public CityDto PickUpCity { get; set; }
        public CityDto ReturnCity { get; set; }
    }
}
