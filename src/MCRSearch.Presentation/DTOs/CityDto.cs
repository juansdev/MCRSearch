using MCRSearch.src.MCRSearch.Presentation.DTOs.Commons;

namespace MCRSearch.src.MCRSearch.Presentation.Dtos
{
    public class CityDto: BaseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentDto? Department { get; set; }
    }
}
