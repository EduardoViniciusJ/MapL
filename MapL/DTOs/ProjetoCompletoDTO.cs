using MapL.DTOs.ComoDTO;
using MapL.DTOs.OQueDTO;
using MapL.DTOs.PorDTO;
using MapL.Models;

namespace MapL.DTOs
{
    public class ProjetoCompletoDTO
    {
        public string Titulo { get; set; }
        public IEnumerable<PorqueCreateDTO> Porques { get; set; }
        public IEnumerable<OQueCreateDTO> Oques { get; set; }
        public IEnumerable<ComoCreateDTO> Comos { get; set; }
    }
}
