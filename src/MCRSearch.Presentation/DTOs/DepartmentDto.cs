using MCRSearch.src.MCRSearch.Core.Entities;

namespace MCRSearch.src.MCRSearch.Presentation.Dtos
{
    public class DepartmentDto
    {
        public string? Name { get; set; }
        public int CountryId { get; set; }
        public CountryDto? Country { get; set; }
    }
}
