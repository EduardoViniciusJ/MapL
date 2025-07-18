﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MapL.Models
{
    public class Motivacao
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "O campo Texto é obrigatório.")]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "O campo Texto deve ter entre 1 e 100 caracteres.")]
        public string? Descricao { get; set; }
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
    }
}
