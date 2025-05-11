using System.ComponentModel.DataAnnotations;

namespace MapL.DTOs.PorDTO
{
    public class MotivacaoCriarDTO
    {
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O campo Texto deve ter entre 1 e 100 caracteres.")]
        public string? Texto { get; set; }
    }
}
