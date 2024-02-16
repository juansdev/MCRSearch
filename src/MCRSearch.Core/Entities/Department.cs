using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCRSearch.src.MCRSearch.Core.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        [ForeignKey("CountryId")]
        public int CountryId { get; set; }
        public required Country Country { get; set; }
    }
}
