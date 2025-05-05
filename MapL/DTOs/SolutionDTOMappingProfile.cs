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
        }
    }
}