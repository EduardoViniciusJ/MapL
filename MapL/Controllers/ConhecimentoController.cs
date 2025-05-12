using AutoMapper;
using MapL.DTOs.OQueDTO;
using MapL.Models;
using MapL.Pagination;
using MapL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MapL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConhecimentoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uof;

        public ConhecimentoController(IMapper mapper, IUnitOfWork uof)
        {
            _mapper = mapper;
            _uof = uof;
        }

        // Obter todos os conhecimentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConhecimentoDTO>>> Get()
        {
            var conhecimentos = await _uof.Conhecimentos.ObterTodasAsync();

            if (conhecimentos == null)
            {
                return NotFound();
            }

            var conhecimentosDTO = _mapper.Map<IEnumerable<ConhecimentoDTO>>(conhecimentos);
            return Ok(conhecimentosDTO);
        }

        // Obter conhecimento por ID
        [HttpGet("{id}/conhecimento")]
        public async Task<ActionResult<ConhecimentoDTO>> GetConhecimentoId(int id)
        {
            var conhecimento = await _uof.Conhecimentos.ObterPorIdAsync(id);

            if (conhecimento == null)
            {
                return NotFound();
            }

            var conhecimentoDTO = _mapper.Map<ConhecimentoDTO>(conhecimento);
            return Ok(conhecimentoDTO);
        }

        // Obter conhecimentos por ID do projeto
        [HttpGet("{id}/projeto")]
        public async Task<ActionResult<IEnumerable<ConhecimentoDTO>>> GetProjetoId(int id)
        {
            var conhecimento = await _uof.Conhecimentos.ObterPorProjetoIdAsync(id);
            if (conhecimento == null)
            {
                return NotFound();
            }

            var conhecimentoDTO = _mapper.Map<IEnumerable<ConhecimentoDTO>>(conhecimento);
            return Ok(conhecimentoDTO);
        }

        // Obter conhecimentos com paginação
        [HttpGet("pagination")]
        public async Task<ActionResult<IEnumerable<ConhecimentoDTO>>> GetConhecimentoPaginacao([FromQuery] QueryStringParameters conhecimentosParameters)
        {
            var conhecimentos = await _uof.Conhecimentos.ObterPorPaginacaoAsync(conhecimentosParameters);

            var metadata = new
            {
                conhecimentos.TotalCount,
                conhecimentos.PageSize,
                conhecimentos.CurrentPage,
                conhecimentos.TotalPage,
                conhecimentos.HasNext,
                conhecimentos.HasPrevious,
            };

            Response.Headers.Append("X-Pagination", System.Text.Json.JsonSerializer.Serialize(metadata));  // Informações para o cliente da paginação

            var conhecimentosDTO = _mapper.Map<IEnumerable<ConhecimentoDTO>>(conhecimentos);
            return Ok(conhecimentosDTO);
        }

        // Criar um novo conhecimento
        [HttpPost]
        public async Task<ActionResult<ConhecimentoDTO>> Post(ConhecimentoDTO conhecimentoDTO)
        {
            if (conhecimentoDTO == null)
            {
                return BadRequest("Dados inválidos");
            }

            var conhecimento = _mapper.Map<Conhecimento>(conhecimentoDTO);
            var conhecimentoCriado = _uof.Conhecimentos.Criar(conhecimento);

            _uof.CommitAsync();

            var conhecimentoCriadoDTO = _mapper.Map<ConhecimentoDTO>(conhecimentoCriado);
            return CreatedAtAction(nameof(Get), new { id = conhecimentoCriadoDTO.Id }, conhecimentoCriadoDTO);
        }

        // Atualizar um conhecimento
        [HttpPut("{projetoId}/conhecimento/{id}")]
        public async Task<ActionResult<ConhecimentoDTO>> Put(int projetoId, int id, ConhecimentoDTO conhecimentoDTO)
        {
            if (conhecimentoDTO is null)
            {
                return BadRequest("Dados inválidos");
            }

            var conhecimento = _mapper.Map<Conhecimento>(conhecimentoDTO);
            var conhecimentoAtualizado = _uof.Conhecimentos.Atualizar(conhecimento, id, projetoId);
            _uof.CommitAsync();

            var conhecimentoAtualizadoDTO = _mapper.Map<ConhecimentoDTO>(conhecimentoAtualizado);
            return Ok(conhecimentoAtualizadoDTO);
        }

        // Deletar um conhecimento
        [HttpDelete("{projetoId}/conhecimento/{id}")]
        public async Task<ActionResult> DeleteOQueAprender(int projetoId, int id)
        {
            var conhecimento = _uof.Conhecimentos.Remover(id, projetoId);
            _uof.CommitAsync();

            if (conhecimento == null)
            {
                return NotFound("Item não encontrado");
            }

            return Ok(conhecimento);
        }
    }
}
