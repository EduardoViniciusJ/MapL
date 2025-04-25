using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MapL.Models
{
    public class OQueAprender
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "O campo Conceito é obrigatório.")]   
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O campo Conceito deve ter entre 1 e 150 caracteres.")]    
        public string? Conceito { get; set; }
        [Required(ErrorMessage = "O campo Fato é obrigatório.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O campo Fato deve ter entre 1 e 150 caracteres.")]
        public string? Fato { get; set; }
        [Required(ErrorMessage = "O campo Procedimento é obrigatório.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O campo Fato deve ter entre 1 e 150 caracteres.")]
        public string? Procedimento { get; set; }
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }    

    }
}
