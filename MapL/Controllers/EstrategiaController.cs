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
    public class EstrategiaController : Controller
    {
        private readonly IEstrategiaRepository _estrategiaRepository;
        private readonly IMapper _mapper;

        public EstrategiaController(IEstrategiaRepository estrategiaRepository, IMapper mapper)
        {
            _estrategiaRepository = estrategiaRepository;
            _mapper = mapper;
        }


        [HttpGet]
        // Obter todas as estratégias
        public ActionResult<IEnumerable<EstrategiaDTO>> Get()
        {
            var estrategias = _estrategiaRepository.ObterTodas();
            if (estrategias is null)
            {
                return NotFound();
            }

            var estrategiasDTO = _mapper.Map<IEnumerable<EstrategiaDTO>>(estrategias);

            return Ok(estrategiasDTO);
        }

        [HttpGet("{id}/estrategia")]
        // Obter estratégia por Id
        public ActionResult<EstrategiaDTO> GetEstrategiaId(int id)
        {
            var estrategia = _estrategiaRepository.ObterPorId(id);
            if (estrategia is null)
            {
                return BadRequest("Não encontrado");
            }
            var estrategiaDTO = _mapper.Map<EstrategiaDTO>(estrategia);

            return Ok(estrategiaDTO);
        }

        [HttpGet("{id}/projeto")]
        // Obter estratégia por projetoId
        public ActionResult<EstrategiaDTO> GetProjetoId(int projetoId)
        {
            var estrategia = _estrategiaRepository.ObterPorProjetoId(projetoId);
            if (estrategia is null)
            {
                return BadRequest("Projeto não econtrado");
            }
            var estrategiaDTO = _mapper.Map<EstrategiaDTO>(estrategia);

            return Ok(estrategiaDTO);
        }

        [HttpPost]
        // Criar uma nova estratégia
        public ActionResult<EstrategiaDTO> Post(EstrategiaDTO estrategiaDTO)
        {
            if (estrategiaDTO is null)
            {

                return BadRequest("Dados inválidos");
            }

            var estrategia = _mapper.Map<Estrategia>(estrategiaDTO);

            var estrategiaNovo = _estrategiaRepository.Criar(estrategia);

            if (estrategiaNovo is null)
            {
                return BadRequest("Erro ao criar o Como Aprender");
            }

            var estrategiaNovoDTO = _mapper.Map<EstrategiaDTO>(estrategiaNovo);

            return CreatedAtAction(nameof(Get), new { id = estrategiaNovoDTO.Id }, estrategiaNovoDTO);
        }

        [HttpPut("{projetoId}/estrategia/{id}")]
        // Atualizar uma estratégia
        public ActionResult<EstrategiaDTO> Put(int projetoId, int id, EstrategiaDTO estrategiaDTO)
        {
            if (estrategiaDTO is null)
            {
                return BadRequest("Dados inválidos");
            }

            var estrategia = _mapper.Map<Estrategia>(estrategiaDTO);

            var estrategiaAtualizado = _estrategiaRepository.Atualizar(estrategia, id, projetoId);

            var estrategiaAtualizadoDTO = _mapper.Map<EstrategiaDTO>(estrategiaAtualizado);

            return Ok(estrategiaAtualizadoDTO);
        }


        [HttpDelete("{projetoId}/estrategia/{id}")]
        // Remover uma estratégia
        public ActionResult Delete(int projetoId, int id)
        {
            var estrategia = _estrategiaRepository.Remover(id, projetoId);

            if(estrategia == null)
            {
                return NotFound("Item não encontrado"); 
            }

            return Ok(estrategia);
        }   




    }
}


