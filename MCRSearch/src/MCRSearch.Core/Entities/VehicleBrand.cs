using MCRSearch.src.MCRSearch.Core.Entities.Commons;
using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.MCRSearch.Core.Entities
{
    public class VehicleBrand : BaseEntity
    {
        [Required]
        public string? Name { get; set; }
    }
}
