using AutoMapper;
using MapL.DTOs.PorDTO;
using MapL.Models;
using MapL.Pagination;
using MapL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MapL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotivacaoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uof;

        public MotivacaoController(IUnitOfWork uof, IMapper mapper)
        {
            _mapper = mapper;
            _uof = uof;
        }

        // Obter todas as motivações
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotivacaoDTO>>> Get()
        {
            var motivacoes = await _uof.Motivacoes.ObterTodasAsync();

            if (motivacoes == null)
            {
                return NotFound();
            }

            var motivacoesDTO = _mapper.Map<IEnumerable<MotivacaoDTO>>(motivacoes);
            return Ok(motivacoesDTO);
        }

        // Obter motivações por ID do projeto
        [HttpGet("{id}/projeto")]
        public async Task<ActionResult<MotivacaoDTO>> GetProjetoId(int id)
        {
            var motivacao = await _uof.Motivacoes.ObterPorProjetoIdAsync(id);

            if (motivacao == null)
            {
                return NotFound();
            }

            var motivacaoDTO = _mapper.Map<IEnumerable<MotivacaoDTO>>(motivacao);
            return Ok(motivacaoDTO);
        }

        // Obter motivação por ID
        [HttpGet("{id}/motivacao")]
        public async Task<ActionResult<MotivacaoDTO>> GetMotivacaoIdAsync(int id)
        {
            var motivacao = await _uof.Motivacoes.ObterPorIdAsync(id);

            if (motivacao == null)
            {
                return NotFound();
            }

            var motivacaoDTO = _mapper.Map<MotivacaoDTO>(motivacao);
            return Ok(motivacaoDTO);
        }

        // Obter motivações com paginação
        [HttpGet("pagination")]
        public async Task<ActionResult<IEnumerable<MotivacaoDTO>>> GetMotivacoesPorPaginacao([FromQuery] QueryStringParameters motivacoesParameters)
        {
            var motivacoes = await _uof.Motivacoes.ObterPorPaginacaoAsync(motivacoesParameters);

            var metadata = new
            {
                motivacoes.TotalCount,
                motivacoes.PageSize,
                motivacoes.CurrentPage,
                motivacoes.TotalPage,
                motivacoes.HasNext,
                motivacoes.HasPrevious,
            };

            Response.Headers.Append("X-Pagination", System.Text.Json.JsonSerializer.Serialize(metadata));

            var motivacoesDTO = _mapper.Map<IEnumerable<MotivacaoDTO>>(motivacoes);
            return Ok(motivacoesDTO);
        }

        // Criar uma nova motivação
        [HttpPost]
        public async Task<ActionResult<MotivacaoDTO>> Post(MotivacaoDTO motivacaoDTO)
        {
            if (motivacaoDTO == null)
            {
                return BadRequest("Dados inválidos");
            }

            var motivacao = _mapper.Map<Motivacao>(motivacaoDTO);
            var motivacaoNovo = _uof.Motivacoes.Criar(motivacao);
            _uof.Commit();
            var motivacaoNovoDTO = _mapper.Map<MotivacaoDTO>(motivacaoNovo);
            return CreatedAtAction(nameof(Get), new { id = motivacaoNovoDTO.Id }, motivacaoNovoDTO);
        }

        // Atualizar uma motivação
        [HttpPut("{projetoId}/porque/{id}")]
        public async Task<ActionResult<MotivacaoDTO>> Put(MotivacaoDTO motivacaoDTO, int projetoId, int id)
        {
            if (motivacaoDTO is null)
            {
                return BadRequest("Dados inválidos");
            }

            var motivacao = _mapper.Map<Motivacao>(motivacaoDTO);
            var motivacaoAtualizado = _uof.Motivacoes.Atualizar(motivacao, projetoId, id);
            _uof.Commit();
            var motivacaoAtualizadoDTO = _mapper.Map<MotivacaoDTO>(motivacaoAtualizado);
            return Ok(motivacaoAtualizadoDTO);
        }

        // Deletar uma motivação
        [HttpDelete("{projetoId}/porque/{id}")]
        public async Task<ActionResult> Delete(int projetoId, int id)
        {
            var motivacao = _uof.Motivacoes.Remover(projetoId, id);
            _uof.Commit();
            if (motivacao == null)
            {
                return NotFound("Item não encontrado");
            }

            return Ok(motivacao);
        }
    }
}
