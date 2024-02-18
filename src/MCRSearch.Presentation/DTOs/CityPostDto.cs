﻿using MCRSearch.src.MCRSearch.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.MCRSearch.Presentation.Dtos
{
    public class CityPostDto
    {
        [Required(ErrorMessage = "El nombre de la ciudad es obligatorio")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "El departamento asociado es obligatorio")]
        public int DepartmentId { get; set; }
    }
}
