﻿using MCRSearch.src.MCRSearch.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.SharedDtos
{
    public class DepartmentPatchDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del departamento es obligatorio")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "El pais asociado es obligatorio")]
        public int CountryId { get; set; }
    }
}
