using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCRSearch.src.MCRSearch.Core.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public required Department Department { get; set; }
    }
}
