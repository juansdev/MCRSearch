using MCRSearch.src.MCRSearch.Core.Entities.Commons;
using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.MCRSearch.Core.Entities
{
    public class VehicleModel : BaseEntity
    {
        [Required]
        public string? Name { get; set; }
    }
}
