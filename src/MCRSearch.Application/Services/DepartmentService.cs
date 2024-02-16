using AutoMapper;
using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using MCRSearch.src.MCRSearch.Presentation.Dtos;

namespace MCRSearch.src.MCRSearch.Application.Services
{
    public class DepartmentService: IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public List<DepartmentDto> GetDepartments()
        {
            var listDepartmentsRepository = _departmentRepository.GetDepartments().Result;
            var listDepartmentsDto = new List<DepartmentDto>();
            foreach(var department in listDepartmentsRepository)
            {
                listDepartmentsDto.Add(_mapper.Map<DepartmentDto>(department));
            }
            return listDepartmentsDto;
        }
    }
}
