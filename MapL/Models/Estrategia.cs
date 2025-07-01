using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MapL.Models
{
    public class Estrategia
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Texto é obrigatório.")]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "O campo Texto deve ter entre 1 e 150 caracteres.")]
        public string? Descricao { get; set; }
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
    }
}
