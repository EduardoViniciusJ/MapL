using MapL.Context;
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


        public ProjetoController(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
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
        public ActionResult<Projeto> GetById(int id)
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


        // Adiciona um conceito a um projeto com base no seu id
        [HttpPost("{id}/conceito")]
        public ActionResult<OQueAprender> PostConceito(OQueAprender conceito, int id)
        {
            if (conceito is null)
            {
                return BadRequest("Dados inválidos");
            }

            var conceitoCriado = _projetoRepository.AddConceito(conceito, id);
            return CreatedAtAction(nameof(GetById), new { id = conceitoCriado.Id }, conceitoCriado);

        }


        // Adiciona um fato a um projeto com base no seu id
        [HttpPost("{id}/fato")]
        public ActionResult<OQueAprender> PostFato(OQueAprender fato, int id)
        {
            if (fato is null)
            {
                return BadRequest("Dados inválidos");
            }

            var fatoCriado = _projetoRepository.AddFato(fato, id);
            return CreatedAtAction(nameof(GetById), new { id = fatoCriado.Id }, fatoCriado);
        }

        // Adiciona um procedimento a um projeto com base no seu id
        [HttpPost("{id}/procedimento")]
        public ActionResult<OQueAprender> PostProcedimento(OQueAprender procedimento, int id)
        {
            if (procedimento is null)
            {
                return BadRequest("Dados inválidos");
            }

            var procedimentoCriado = _projetoRepository.AddProcedimento(procedimento, id);
            return CreatedAtAction(nameof(GetById), new { id = procedimentoCriado.Id }, procedimentoCriado);
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

            if(projetoDeletado is null)
            {
                return NotFound("Projeto não encontrado.");
            }
            
            return Ok(projetoDeletado);
        }
    }
}
