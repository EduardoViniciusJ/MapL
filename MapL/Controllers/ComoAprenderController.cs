using AutoMapper;
using MapL.DTOs;
using MapL.DTOs.ComoDTO;
using MapL.Models;
using MapL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MapL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComoAprenderController : Controller
    {
        private readonly IComoAprenderRepository _comoAprenderRepository;
        private readonly IMapper _mapper;

        public ComoAprenderController(IComoAprenderRepository comoAprenderRepository, IMapper mapper)
        {
            _comoAprenderRepository = comoAprenderRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<ComoAprenderDTO>> Get()
        {
            var comoAprender = _comoAprenderRepository.ComoAprenderGet();
            if (comoAprender is null)
            {
                return NotFound();
            }

            var comoAprenderDTO = _mapper.Map<IEnumerable<ComoAprenderDTO>>(comoAprender);

            return Ok(comoAprenderDTO);
        }

        [HttpGet("{id}/como")]
        public ActionResult<ComoAprenderDTO> GetComoAprender(int id)
        {
            var comoAprender = _comoAprenderRepository.ComoAprenderGetIdComo(id);
            if (comoAprender is null)
            {
                return BadRequest("Não encontrado");
            }
            var comoAprenderDTO = _mapper.Map<ComoAprenderDTO>(comoAprender);

            return Ok(comoAprenderDTO);
        }

        [HttpGet("{id}/projeto")]
        public ActionResult<ComoAprenderDTO> GetComoAprenderProjeto(int id)
        {
            var comoAprender = _comoAprenderRepository.ComoAprenderGetIdProjeto(id);
            if (comoAprender is null)
            {
                return BadRequest("Projeto não econtrado");
            }
            var comoAprenderDTO = _mapper.Map<ComoAprenderDTO>(comoAprender);

            return Ok(comoAprenderDTO);
        }
        [HttpPost]
        public ActionResult<ComoAprenderDTO> PostComoAprender(ComoAprenderDTO comoAprenderDTO)
        {
            if (comoAprenderDTO is null)
            {

                return BadRequest("Dados inválidos");
            }

            var comoAprender = _mapper.Map<ComoAprender>(comoAprenderDTO);

            var comoAprenderNovo = _comoAprenderRepository.ComoAprenderPost(comoAprender);

            if (comoAprenderNovo is null)
            {
                return BadRequest("Erro ao criar o Como Aprender");
            }

            var comoAprenderNovoDTO = _mapper.Map<ComoAprenderDTO>(comoAprenderNovo);

            return CreatedAtAction(nameof(GetComoAprender), new { id = comoAprenderNovo.Id }, comoAprenderNovoDTO);
        }

        [HttpPut("{projetoId}/como/{id}")]
        public ActionResult<ComoAprenderDTO> PutComoAprender(int projetoId, int id, ComoAprenderDTO comoAprenderDTO)
        {
            if (comoAprenderDTO is null)
            {
                return BadRequest("Dados inválidos");
            }

            var comoAprender = _mapper.Map<ComoAprender>(comoAprenderDTO);

            var comoAprenderAtualizado = _comoAprenderRepository.ComoAprenderPut(comoAprender, projetoId, id);

            var comoAprenderAtualizadoDTO = _mapper.Map<ComoAprenderDTO>(comoAprenderAtualizado);

            return Ok(comoAprenderAtualizadoDTO);
        }

        [HttpDelete("{projetoId}/como/{id}")]
        public ActionResult DeleteComoAprender(int projetoId, int id)
        {
            var deletado = _comoAprenderRepository.ComoAprenderDelete(projetoId, id);

            if(deletado == null)
            {
                return NotFound("Item não encontrado"); 
            }

            return Ok(deletado);
        }   




    }
}


