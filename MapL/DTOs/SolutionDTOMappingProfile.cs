using AutoMapper;
using MapL.Models;

namespace MapL.DTOs
{
    public class SolutionDTOMappingProfile : Profile
    {
        public SolutionDTOMappingProfile()
        {
            CreateMap<OQueAprenderDTO, OQueAprender>().ReverseMap();
            CreateMap<ProjetoDTO, Projeto>().ReverseMap();
            CreateMap<ComoAprenderDTO, ComoAprender>().ReverseMap();
            CreateMap<PorqueAprenderDTO, PorqueAprender>().ReverseMap();
            
         
        }
    }
}