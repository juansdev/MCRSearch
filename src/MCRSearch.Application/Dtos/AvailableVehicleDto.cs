using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.MCRSearch.Application.Dtos
{
    public class AvailableVehicleDto
    {
        public int vehicleId { get; set; }
        public int pickUpCityId { get; set; }
        public int returnCityId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
