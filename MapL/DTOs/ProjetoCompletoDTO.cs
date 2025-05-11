using MapL.DTOs.ComoDTO;
using MapL.DTOs.OQueDTO;
using MapL.DTOs.PorDTO;
using MapL.Models;

namespace MapL.DTOs
{
    public class ProjetoCompletoDTO
    {
        public string Titulo { get; set; }
        public IEnumerable<MotivacaoCriarDTO> Motivacoes { get; set; }
        public IEnumerable<ConhecimentoCriarDTO> Conhecimentos { get; set; }
        public IEnumerable<EstrategiaCriarDTO> Estrategias { get; set; }
    }
}
