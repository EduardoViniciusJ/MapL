using System.ComponentModel.DataAnnotations;

namespace MapL.DTOs
{
    public class PorqueAprenderDTO
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O campo Texto deve ter entre 1 e 100 caracteres.")]
        public string? Texto { get; set; }
        public int ProjetoId { get; set; }
    }
}
