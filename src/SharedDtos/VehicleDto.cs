using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Presentation.DTOs.Commons;

namespace MCRSearch.src.SharedDtos
{
    public class VehicleDto : BaseDto
    {
        public int Id { get; set; }
        public int VehicleBrandId { get; set; }
        public VehicleBrand? VehicleBrand { get; set; }
        public int VehicleModelId { get; set; }
        public VehicleModel? VehicleModel { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType? VehicleType { get; set; }
    }
}
