using AutoMapper;
using MapL.Context;
using MapL.DTOs;
using MapL.Models;
using MapL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : Controller
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IMapper _mapper;

        public ProjetoController(IProjetoRepository projetoRepository, IMapper mapper)
        {
            _projetoRepository = projetoRepository;
            _mapper = mapper;
        }


        [HttpGet]
        // Mostrar todos os projetos
        public ActionResult<IEnumerable<Projeto>> Get()
        {
            var projetos = _projetoRepository.ObterTodas().ToList();
            if (projetos is null)
            {
                return NotFound("Nenhum projeto encontrado.");
            }
            return Ok(projetos);

        }

        [HttpGet("{id:int}")]
        // Mostra um projeto com base no seu id
        public ActionResult GetId(int id)
        {
            var projeto = _projetoRepository.ObterPorId(id);
            if (projeto is null)
            {
                return NotFound("Projeto não encontrado.");
            }
            return Ok(projeto);
        }


        [HttpPost]
        // Criar o projeto mas sem os detalhes
        public ActionResult<ProjetoDTO> Post(ProjetoDTO projetoDTO)
        {
            if (projetoDTO is null)
            {
                return BadRequest("Dados inválidos");
            }

            var projeto = _mapper.Map<Projeto>(projetoDTO);

            var projetoCriado = _projetoRepository.Criar(projeto);

            var projetoCriadoDTO = _mapper.Map<ProjetoDTO>(projetoCriado);

            return CreatedAtAction(nameof(GetId), new { id = projetoCriadoDTO.Id }, projetoCriadoDTO);
        }

        [HttpPost("/api/completo")]
        // Criar um projeto completo 
        public ActionResult<ProjetoCompletoDTO> PostCompleto(ProjetoCompletoDTO projetoCompletoDTO)
        {
            if (projetoCompletoDTO is null)
            {
                return BadRequest("Dados inválidos");
            }

            var projeto = _mapper.Map<Projeto>(projetoCompletoDTO);

            var projetoCriado = _projetoRepository.CriarProjetoCompleto(projeto);

            var projetoCriadoDTO = _mapper.Map<ProjetoCompletoDTO>(projetoCriado);

            return Ok(projetoCriadoDTO);

        }


        [HttpPut("{id}")]
        // Atualizar um projeto 
        public ActionResult<ProjetoDTO> Put(int id, ProjetoDTO projetoDTO)
        {
            if (id != projetoDTO.Id)
            {
                return BadRequest("Dados inválidos");
            }

            var projeto = _mapper.Map<Projeto>(projetoDTO); 

            var projetoAtualizado = _projetoRepository.Atualizar(projeto);

            var projetoCriadoDTO = _mapper.Map<ProjetoDTO>(projetoAtualizado);

            return Ok(projetoCriadoDTO);

        }

        [HttpDelete("{id:int}")]
        // Deletar um projeto
        public ActionResult<ProjetoDTO> Delete(int id)
        {
            var projeto = _projetoRepository.Remover(id);

            if (projeto is null)
            {
                return NotFound("Projeto não encontrado.");
            }

            var projetoDeletadoDTO = _mapper.Map<ProjetoDTO>(projeto);

            return Ok(projetoDeletadoDTO);
        }
    }
}
