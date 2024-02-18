using MCRSearch.src.MCRSearch.Application.Dtos;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Presentation.Dtos;

namespace MCRSearch.src.MCRSearch.Application.Services.Interfaces
{
    public interface IDepartmentService
    {
        List<DepartmentDto> GetDepartments();
        DepartmentDto GetDepartment(int id);
        DepartmentDto GetDepartment(string name);
        ResponseAPI<Department> CreateDepartment(DepartmentPostDto departmentDto);
        ResponseAPI<Department> PatchDepartment(DepartmentPatchDto departmentDto);
        ResponseAPI<Department> DeleteDepartment(int departmentId);
    }
}
