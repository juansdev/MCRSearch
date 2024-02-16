using MCRSearch.src.MCRSearch.Core.Entities;

namespace MCRSearch.src.MCRSearch.Presentation.Dtos
{
    public class VehicleDto
    {
        public int VehicleBrandId { get; set; }
        public VehicleBrand? VehicleBrand { get; set; }
        public int VehicleModelId { get; set; }
        public VehicleModel? VehicleModel { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType? VehicleType { get; set; }
    }
}
