using AutoMapper;
using MapL.DTOs;
using MapL.DTOs.ComoDTO;
using MapL.Models;
using MapL.Pagination;
using MapL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MapL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstrategiaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uof;

        public EstrategiaController(IUnitOfWork uof, IMapper mapper)
        {
            _mapper = mapper;
            _uof = uof;
        }

        // Obter todas as estratégias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstrategiaDTO>>> Get()
        {
            var estrategias = await _uof.Estrategias.ObterTodasAsync();
            if (estrategias is null)
            {
                return NotFound();
            }

            var estrategiasDTO = _mapper.Map<IEnumerable<EstrategiaDTO>>(estrategias);
            return Ok(estrategiasDTO);
        }

        // Obter estratégia por Id
        [HttpGet("{id}/estrategia")]
        public async Task<ActionResult<EstrategiaDTO>> GetEstrategiaId(int id)
        {
            var estrategia = await _uof.Estrategias.ObterPorIdAsync(id);
            if (estrategia is null)
            {
                return BadRequest("Não encontrado");
            }
            var estrategiaDTO = _mapper.Map<EstrategiaDTO>(estrategia);

            return Ok(estrategiaDTO);
        }

        // Obter estratégia por projetoId
        [HttpGet("{id}/projeto")]
        public async Task<ActionResult<EstrategiaDTO>> GetProjetoId(int id)
        {
            var estrategia = await _uof.Estrategias.ObterPorProjetoIdAsync(id);

            if (estrategia is null)
            {
                return BadRequest("Projeto não encontrado");
            }
            var estrategiaDTO = _mapper.Map<IEnumerable<EstrategiaDTO>>(estrategia);

            return Ok(estrategiaDTO);
        }

        // Obter estratégias por paginação
        [HttpGet("pagination")]
        public async Task<ActionResult<IEnumerable<EstrategiaDTO>>> GetEstrategiasPorPaginacao([FromQuery] QueryStringParameters estrategiasParameters)
        {
            var conhecimentos = await _uof.Estrategias.ObterPorPaginacaoAsync(estrategiasParameters);

            var metadata = new
            {
                conhecimentos.TotalCount,
                conhecimentos.PageSize,
                conhecimentos.CurrentPage,
                conhecimentos.TotalPage,
                conhecimentos.HasNext,
                conhecimentos.HasPrevious,
            };

            Response.Headers.Append("X-Pagination", System.Text.Json.JsonSerializer.Serialize(metadata));

            var estrategiasDTO = _mapper.Map<IEnumerable<EstrategiaDTO>>(conhecimentos);
            return Ok(estrategiasDTO);
        }

        //  Criar uma nova estratégia
        [HttpPost]
        public async Task<ActionResult<EstrategiaDTO>> Post(EstrategiaDTO estrategiaDTO)
        {
            if (estrategiaDTO is null)
            {
                return BadRequest("Dados inválidos");
            }

            var estrategia = _mapper.Map<Estrategia>(estrategiaDTO);
            var estrategiaNovo = _uof.Estrategias.Criar(estrategia);

            _uof.Commit();

            var estrategiaNovoDTO = _mapper.Map<EstrategiaDTO>(estrategiaNovo);
            return CreatedAtAction(nameof(Get), new { id = estrategiaNovoDTO.Id }, estrategiaNovoDTO);
        }

        // Atualizar uma estratégia
        [HttpPut("{projetoId}/estrategia/{id}")]
        public async Task<ActionResult<EstrategiaDTO>> Put(int projetoId, int id, EstrategiaDTO estrategiaDTO)
        {
            if (estrategiaDTO is null)
            {
                return BadRequest("Dados inválidos");
            }

            var estrategia = _mapper.Map<Estrategia>(estrategiaDTO);
            var estrategiaAtualizado = _uof.Estrategias.Atualizar(estrategia, id, projetoId);

            _uof.Commit();

            var estrategiaAtualizadoDTO = _mapper.Map<EstrategiaDTO>(estrategiaAtualizado);
            return Ok(estrategiaAtualizadoDTO);
        }

        // Remover uma estratégia
        [HttpDelete("{projetoId}/estrategia/{id}")]
        public async Task<ActionResult> Delete(int projetoId, int id)
        {
            var estrategia = _uof.Estrategias.Remover(id, projetoId);

            _uof.Commit();

            if (estrategia == null)
            {
                return NotFound("Item não encontrado");
            }

            return Ok(estrategia);
        }
    }
}
