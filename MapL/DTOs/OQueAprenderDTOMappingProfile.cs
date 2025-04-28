using AutoMapper;
using MapL.Models;

namespace MapL.DTOs
{
    public class OQueAprenderDTOMappingProfile : Profile
    {
        public OQueAprenderDTOMappingProfile()
        {
            CreateMap<OQueAprenderDTO, OQueAprender>().ReverseMap();
        }
    }
}