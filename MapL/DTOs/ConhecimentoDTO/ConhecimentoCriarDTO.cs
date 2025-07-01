using System.ComponentModel.DataAnnotations;

namespace MapL.DTOs.OQueDTO
{
    public class ConhecimentoCriarDTO
    {

        [StringLength(150, MinimumLength = 1, ErrorMessage = "O campo Conceito deve ter entre 1 e 150 caracteres.")]
        public string? Conceito { get; set; }

        [StringLength(150, MinimumLength = 1, ErrorMessage = "O campo Fato deve ter entre 1 e 150 caracteres.")]
        public string? Fato { get; set; }

        [StringLength(150, MinimumLength = 1, ErrorMessage = "O campo Fato deve ter entre 1 e 150 caracteres.")]
        public string? Procedimento { get; set; }
    }
}
