using MCRSearch.src.MCRSearch.Core.Entities;

namespace MCRSearch.src.MCRSearch.Presentation.Dtos
{
    public class CityDto
    {
        public string? Name { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentDto? Department { get; set; }
    }
}
