﻿using MCRSearch.src.MCRSearch.Presentation.Dtos;

namespace MCRSearch.src.MCRSearch.Application.Services.Interfaces
{
    public interface IDepartmentService
    {
        public List<DepartmentDto> GetDepartments();
    }
}
