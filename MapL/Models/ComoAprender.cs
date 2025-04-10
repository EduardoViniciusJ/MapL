using System.ComponentModel.DataAnnotations;

namespace MapL.Models
{
    public class ComoAprender
    {
        public int  Id { get; set; }
        [Required(ErrorMessage = "O campo Texto é obrigatório.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O campo Texto deve ter entre 1 e 150 caracteres.")]
        public string? Texto { get; set; }
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
    }
}
