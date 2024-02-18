namespace MCRSearch.src.MCRSearch.Presentation.DTOs.Commons
{
    public class BaseDto
    {
        public DateTime CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public BaseDto()
        {
            UpdatedDate = null;
        }
    }
}
