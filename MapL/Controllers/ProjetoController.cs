using AutoMapper;
using MapL.Context;
using MapL.DTOs;
using MapL.Models;
using MapL.Pagination;
using MapL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uof;

        public ProjetoController(IUnitOfWork uof, IMapper mapper)
        {
            _mapper = mapper;
            _uof = uof;
        }

        [HttpGet]
        // Mostrar todos os projetos
        public async Task<ActionResult<IEnumerable<Projeto>>> Get()
        {
            var projetos = await _uof.Projetos.ObterTodasAsync();
            if (projetos is null)
            {
                return NotFound("Nenhum projeto encontrado.");
            }
            return Ok(projetos);
        }

        [HttpGet("{id:int}")]
        // Mostra um projeto com base no seu id
        public async Task<ActionResult> GetId(int id)
        {
            var projeto = await _uof.Projetos.ObterPorIdAsync(id);
            if (projeto is null)
            {
                return NotFound("Projeto não encontrado.");
            }
            return Ok(projeto);
        }

        [HttpGet("pagination")]
        // Obter projetos por paginação
        public async Task<ActionResult<IEnumerable<ProjetoDTO>>> GetProjetoPorPaginacao([FromQuery] QueryStringParameters projetosParameters)
        {
            var projetos = await _uof.Projetos.ObterPorPaginacaoAsync(projetosParameters);

            var metadata = new
            {
                projetos.TotalCount,
                projetos.PageSize,
                projetos.CurrentPage,
                projetos.TotalPage,
                projetos.HasNext,
                projetos.HasPrevious,
            };

            Response.Headers.Append("X-Pagination", System.Text.Json.JsonSerializer.Serialize(metadata));

            var projetosDTO = _mapper.Map<IEnumerable<ProjetoDTO>>(projetos);

            return Ok(projetosDTO);
        }

        [HttpPost]
        // Criar o projeto mas sem os detalhes
        public async Task<ActionResult<ProjetoDTO>> Post(ProjetoDTO projetoDTO)
        {
            if (projetoDTO is null)
            {
                return BadRequest("Dados inválidos");
            }

            var projeto = _mapper.Map<Projeto>(projetoDTO);

            var projetoCriado = _uof.Projetos.Criar(projeto);

            _uof.Commit();
            var projetoCriadoDTO = _mapper.Map<ProjetoDTO>(projetoCriado);

            return CreatedAtAction(nameof(GetId), new { id = projetoCriadoDTO.Id }, projetoCriadoDTO);
        }

        [HttpPost("/api/completo")]
        // Criar um projeto completo 
        public async Task<ActionResult<ProjetoCompletoDTO>> PostCompleto(ProjetoCompletoDTO projetoCompletoDTO)
        {
            if (projetoCompletoDTO is null)
            {
                return BadRequest("Dados inválidos");
            }

            var projeto = _mapper.Map<Projeto>(projetoCompletoDTO);

            var projetoCriado = _uof.Projetos.CriarProjetoCompleto(projeto);

            _uof.Commit();
            var projetoCriadoDTO = _mapper.Map<ProjetoCompletoDTO>(projetoCriado);

            return Ok(projetoCriadoDTO);
        }

        [HttpPut("{id}")]
        // Atualizar um projeto 
        public async Task<ActionResult<ProjetoDTO>> Put(int id, ProjetoDTO projetoDTO)
        {
            if (id != projetoDTO.Id)
            {
                return BadRequest("Dados inválidos");
            }

            var projeto = _mapper.Map<Projeto>(projetoDTO);

            var projetoAtualizado = _uof.Projetos.Atualizar(projeto);

            _uof.Commit();
            var projetoCriadoDTO = _mapper.Map<ProjetoDTO>(projetoAtualizado);

            return Ok(projetoCriadoDTO);
        }

        [HttpDelete("{id:int}")]
        // Deletar um projeto
        public async Task<ActionResult<ProjetoDTO>> Delete(int id)
        {
            var projeto = _uof.Projetos.Remover(id);

            _uof.Commit();
            if (projeto is null)
            {
                return NotFound("Projeto não encontrado.");
            }

            var projetoDeletadoDTO = _mapper.Map<ProjetoDTO>(projeto);

            return Ok(projetoDeletadoDTO);
        }
    }
}
