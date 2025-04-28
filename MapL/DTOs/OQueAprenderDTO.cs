using MapL.Models;
using System.ComponentModel.DataAnnotations;

namespace MapL.DTOs
{
    public class OQueAprenderDTO
    {
       
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O campo Conceito deve ter entre 1 e 150 caracteres.")]
        public string? Conceito { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O campo Fato deve ter entre 1 e 150 caracteres.")]
        public string? Fato { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O campo Fato deve ter entre 1 e 150 caracteres.")]
        public string? Procedimento { get; set; }
    }
}
