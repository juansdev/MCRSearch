using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.MCRSearch.Core.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
