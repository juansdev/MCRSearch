﻿using System.ComponentModel.DataAnnotations;

namespace MCRSearch.src.SharedDtos
{
    public class CountryPostDto
    {
        [Required(ErrorMessage = "El nombre del pais es obligatorio")]
        public string? Name { get; set; }
    }
}
