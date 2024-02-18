using MCRSearch.src.MCRSearch.Presentation.DTOs.Commons;

namespace MCRSearch.src.SharedDtos
{
    public class DepartmentDto : BaseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CountryId { get; set; }
        public CountryDto? Country { get; set; }
    }
}
