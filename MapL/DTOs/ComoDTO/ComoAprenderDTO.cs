using System.ComponentModel.DataAnnotations;

namespace MapL.DTOs.ComoDTO
{
    public class ComoAprenderDTO
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O campo Texto deve ter entre 1 e 150 caracteres.")]
        public string? Texto { get; set; }
        public int ProjetoId { get; set; }

    }
}
