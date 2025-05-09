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
            CreateMap<ProjetoCompletoDTO, Projeto>().ReverseMap();

            CreateMap<PorqueCreateDTO, PorqueAprender>().ReverseMap();
            CreateMap<ComoCreateDTO, ComoAprender>().ReverseMap();
            CreateMap<OQueCreateDTO, OQueAprender>().ReverseMap();

            
         
        }
    }
}