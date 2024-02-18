using MCRSearch.src.MCRSearch.Core.Entities.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCRSearch.src.MCRSearch.Core.Entities
{
    public class City : BaseEntity
    {
        [Required]
        public string? Name { get; set; }
        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
