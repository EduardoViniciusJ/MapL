using AutoMapper;
using MapL.DTOs.ComoDTO;
using MapL.DTOs.OQueDTO;
using MapL.DTOs.PorDTO;
using MapL.Models;


namespace MapL.DTOs
{
    public class SolutionDTOMappingProfile : Profile
    {
        public SolutionDTOMappingProfile()
        {
            CreateMap<ConhecimentoDTO, Conhecimento>().ReverseMap();
            CreateMap<ProjetoDTO, Projeto>().ReverseMap();
            CreateMap<EstrategiaDTO, Estrategia>().ReverseMap();
            CreateMap<MotivacaoDTO, Motivacao>().ReverseMap();
            CreateMap<ProjetoCompletoDTO, Projeto>().ReverseMap();

            CreateMap<MotivacaoCriarDTO, Motivacao>().ReverseMap();
            CreateMap<EstrategiaCriarDTO, Estrategia>().ReverseMap();
            CreateMap<ConhecimentoCriarDTO, Conhecimento>().ReverseMap();      
         
        }
    }
}