﻿using System.ComponentModel.DataAnnotations;

namespace MapL.DTOs.ComoDTO
{
    public class EstrategiaCriarDTO
    {
        [StringLength(150, MinimumLength = 1, ErrorMessage = "O campo Texto deve ter entre 1 e 150 caracteres.")]
        public string? Descricao { get; set; }
    }
}
