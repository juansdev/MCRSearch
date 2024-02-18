using MCRSearch.src.MCRSearch.Core.Entities.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCRSearch.src.MCRSearch.Core.Entities
{
    public class Department : BaseEntity
    {
        [Required]
        public string? Name { get; set; }
        public List<City>? Cities { get; set; }
        [ForeignKey("CountryId")]
        public int CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
