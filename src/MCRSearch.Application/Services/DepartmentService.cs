using AutoMapper;
using MCRSearch.src.MCRSearch.Application.Dtos;
using MCRSearch.src.MCRSearch.Application.Services.Interfaces;
using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using MCRSearch.src.MCRSearch.Presentation.Dtos;
using System.Net;

namespace MCRSearch.src.MCRSearch.Application.Services
{
    public class DepartmentService: IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        protected ResponseAPI<Department> _responseApi;
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _responseApi = new ResponseAPI<Department>();
        }

        /// <summary>
        /// Obtiene todos los departamentos.
        /// </summary>
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

        /// <summary>
        /// Obtiene el departamento por ID.
        /// </summary>
        public DepartmentDto GetDepartment(int id)
        {
            var department = _departmentRepository.GetDepartment(id).Result;
            return _mapper.Map<DepartmentDto>(department);
        }

        /// <summary>
        /// Obtiene el departamento por nombre.
        /// </summary>
        public DepartmentDto GetDepartment(string name)
        {
            var department = _departmentRepository.GetDepartment(name).Result;
            return _mapper.Map<DepartmentDto>(department);
        }

        /// <summary>
        /// Crea el departamento.
        /// </summary>
        public ResponseAPI<Department> CreateDepartment(DepartmentDto departmentDto)
        {
            if (_departmentRepository.GetDepartment(departmentDto.Name).Result != null)
            {
                _responseApi.StatusCode = HttpStatusCode.BadRequest;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add("El nombre del departamento ya existe");
                return _responseApi;
            }
            var department = _mapper.Map<Department>(departmentDto);
            if (!_departmentRepository.CreateDeparment(department).Result)
            {
                _responseApi.StatusCode = HttpStatusCode.InternalServerError;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add($"Algo salio mal guardando el registro {department.Name}");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.OK;
            _responseApi.IsSuccess = true;
            _responseApi.Result = department;
            return _responseApi;
        }

        /// <summary>
        /// Actualiza el departamento.
        /// </summary>
        public ResponseAPI<Department> PatchDepartment(DepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);
            if (!_departmentRepository.UpdateDepartmentModel(department).Result)
            {
                _responseApi.StatusCode = HttpStatusCode.InternalServerError;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add($"Algo salio mal guardando el registro {department.Name}");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.NoContent;
            _responseApi.IsSuccess = true;
            return _responseApi;
        }

        /// <summary>
        /// Elimnina el departamento.
        /// </summary>
        public ResponseAPI<Department> DeleteDepartment(int departmentId)
        {
            var department = _departmentRepository.GetDepartment(departmentId).Result;
            if (!_departmentRepository.DeleteDepartmentModel(department).Result)
            {
                _responseApi.StatusCode = HttpStatusCode.InternalServerError;
                _responseApi.IsSuccess = false;
                _responseApi.ErrorMessages.Add($"Algo salio mal eliminando el registro {department.Name}");
                return _responseApi;
            }
            _responseApi.StatusCode = HttpStatusCode.NoContent;
            _responseApi.IsSuccess = true;
            return _responseApi;
        }
    }
}
