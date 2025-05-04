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
        public ActionResult<Projeto> Post(Projeto projeto)
        {
            if (projeto is null)
            {
                return BadRequest("Dados inválidos");
            }
            var projetoCriado = _projetoRepository.Create(projeto);

            return CreatedAtAction(nameof(GetById), new { id = projetoCriado.Id }, projetoCriado);
        }

        [HttpPost("{id}/adi")]
        public ActionResult<OQueAprenderDTO> PostOQueAprender(int id, OQueAprenderDTO oQueAprenderDTO)
        {
            if (oQueAprenderDTO is null)
            {
                return BadRequest("Dados inválidos.");
            }


            var projetoExistente = _projetoRepository.GetById(id);
            if (projetoExistente == null)
            {
                return NotFound("Projeto não encontrado.");
            }

            // Faz o mapeamento DTO -> Entidade
            var oQueAprender = _mapper.Map<OQueAprender>(oQueAprenderDTO);

            // Associa o ProjetoId
            oQueAprender.ProjetoId = id;

            // Salva no banco
            var novoOQueAprender = _projetoRepository.OQueAprenderPost(oQueAprender, id);

            // Faz o mapeamento Entidade -> DTO para retornar
            var oQueAprenderCriado = _mapper.Map<OQueAprenderDTO>(novoOQueAprender);

            return CreatedAtAction(nameof(GetById), new { id = novoOQueAprender.Id }, oQueAprenderCriado);
        }


        [HttpPut("{id}/ad")]
        public ActionResult<OQueAprenderDTO> PutOQueAprender(int id, OQueAprenderDTO oQueAprenderDTO)
        {
            if (oQueAprenderDTO is null)
            {
                BadRequest("Dados inválidos");
            }

            var projetoExistente = _projetoRepository.GetById(id);   

            if (projetoExistente == null)
            {
                return NotFound("Projeto não encontrado.");
            }   

            var oQueAprender = _mapper.Map<OQueAprender>(oQueAprenderDTO);

            oQueAprender.ProjetoId = id;

            var oQueAprenderAtualizado = _projetoRepository.OQueAprenderPut(oQueAprender);

            var oQueAprenderDTOAtualizado = _mapper.Map<OQueAprenderDTO>(oQueAprenderAtualizado);

            return Ok(oQueAprenderDTOAtualizado);   

        }






        // Atualizar um projeto 
        [HttpPut("{id:int}")]
        public ActionResult<Projeto> Put(int id, Projeto projeto)
        {
            if (id != projeto.Id)
            {
                return BadRequest("Dados inválidos");
            }

            var projetoAtualizado = _projetoRepository.Update(projeto);
            return Ok(projetoAtualizado);

        }

        // Deletar um projeto
        [HttpDelete("{id:int}")]
        public ActionResult<Projeto> Delete(int id)
        {
            var projetoDeletado = _projetoRepository.Delete(id);

            if (projetoDeletado is null)
            {
                return NotFound("Projeto não encontrado.");
            }

            return Ok(projetoDeletado);
        }
    }
}
