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

        // Mostrar todos os projetos
        [HttpGet]
        public ActionResult<IEnumerable<Projeto>> Get()
        {
            var projetos = _projetoRepository.GetAll().ToList();
            if (projetos is null)
            {
                return NotFound("Nenhum projeto encontrado.");
            }
            return Ok(projetos);

        }
        // Mostra um projeto com base no seu id
        [HttpGet("{id:int}")]
        public ActionResult GetById(int id)
        {
            var projeto = _projetoRepository.GetById(id);
            if (projeto is null)
            {
                return NotFound("Projeto não encontrado.");
            }
            return Ok(projeto);
        }

        // Criar um novo projeto
        [HttpPost]
        public ActionResult<ProjetoDTO> Post(ProjetoDTO projetoDTO)
        {
            if (projetoDTO is null)
            {
                return BadRequest("Dados inválidos");
            }

            var projeto = _mapper.Map<Projeto>(projetoDTO);  

            var projetoCriado = _projetoRepository.Create(projeto);

            var projetoCriadoDTO = _mapper.Map<ProjetoDTO>(projetoCriado);  

            return CreatedAtAction(nameof(GetById), new { id = projetoCriadoDTO.Id }, projetoCriadoDTO);
        }

        // Atualizar um projeto 
        [HttpPut("{id:int}")]
        public ActionResult<ProjetoDTO> Put(int id, ProjetoDTO projetoDTO)
        {
            if (id != projetoDTO.Id)
            {
                return BadRequest("Dados inválidos");
            }

            var projeto = _mapper.Map<Projeto>(projetoDTO); 

            var projetoAtualizado = _projetoRepository.Update(projeto);

            var projetoCriadoDTO = _mapper.Map<ProjetoDTO>(projetoAtualizado);

            return Ok(projetoCriadoDTO);

        }

        // Deletar um projeto
        [HttpDelete("{id:int}")]
        public ActionResult<ProjetoDTO> Delete(int id)
        {
            var projeto = _projetoRepository.Delete(id);

            if (projeto is null)
            {
                return NotFound("Projeto não encontrado.");
            }

            var projetoDeletadoDTO = _mapper.Map<ProjetoDTO>(projeto);

            return Ok(projetoDeletadoDTO);
        }
    }
}
