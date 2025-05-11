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
            CreateMap<OQueAprenderDTO, Conhecimento>().ReverseMap();
            CreateMap<ProjetoDTO, Projeto>().ReverseMap();
            CreateMap<ComoAprenderDTO, Estrategia>().ReverseMap();
            CreateMap<PorqueAprenderDTO, Motivacao>().ReverseMap();
            CreateMap<ProjetoCompletoDTO, Projeto>().ReverseMap();

            CreateMap<PorqueCreateDTO, Motivacao>().ReverseMap();
            CreateMap<ComoCreateDTO, Estrategia>().ReverseMap();
            CreateMap<OQueCreateDTO, Conhecimento>().ReverseMap();

            
         
        }
    }
}