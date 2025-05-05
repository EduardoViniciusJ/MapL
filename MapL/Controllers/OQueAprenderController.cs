using AutoMapper;
using MapL.DTOs;
using MapL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MapL.Controllers
{
    public class OQueAprenderController : Controller
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IMapper _mapper;


        public OQueAprenderController(IProjetoRepository projetoRepository, IMapper mapper)
        {
            _projetoRepository = projetoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OQueAprenderDTO>> Get()
        {

        }
    }
}
