using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.MCRSearch.Core.Entities.Commons
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }

        public BaseEntity()
        {
            UpdatedDate = null;
        }
    }
}
