using MCRSearch.src.MCRSearch.Core.Entities.Commons;
using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.MCRSearch.Core.Entities
{
    public class Country : BaseEntity
    {
        [Required]
        public string? Name { get; set; }
        public List<Department>? Departments { get; set; }
    }
}
