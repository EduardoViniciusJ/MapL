using System.ComponentModel.DataAnnotations;

namespace MapL.DTOs.ComoDTO
{
    public class EstrategiaCriarDTO
    {
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O campo Texto deve ter entre 1 e 150 caracteres.")]
        public string? Texto { get; set; }
    }
}
