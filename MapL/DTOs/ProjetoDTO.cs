using System.ComponentModel.DataAnnotations;


namespace MapL.DTOs
{
    public class ProjetoDTO
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Titulo é obrigatório.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O campo Titulo deve ter entre 5 e 50 caracteres.")]
        public string Titulo { get; set; }
    }
}
