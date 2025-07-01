using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MapL.Models
{
    public class Projeto
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "O campo Titulo é obrigatório.")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "O campo Titulo deve ter entre 5 e 50 caracteres.")]
        public string Titulo { get; set; }

        public IEnumerable<Motivacao> Motivacoes { get; set; }
        public IEnumerable<Conhecimento> Conhecimentos { get; set; }
        public IEnumerable<Estrategia> Estrategias { get; set; }
    }
}
