using MapL.Context;
using MapL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : Controller
    {
        private readonly AppDbContext _context;

        public ProjetoController(AppDbContext context)
        {
            _context = context;
        }

        // Mostrar todos os projetos
        [HttpGet]
        public ActionResult<IEnumerable<Projeto>> Get()
        {
            var produtos = _context.Projeto.Include(p => p.Porques)
                                            .Include(p => p.Oques)
                                            .Include(p => p.Comos)
                                            .ToList();
            return Ok(produtos);
        }

        // Mostra um projeto com base no seu id
        [HttpGet("{id:int}")]
        public ActionResult<IEnumerable<Projeto>> GetById(int id)
        {
            var projeto = _context.Projeto.Include(p => p.Porques)
                                            .Include(p => p.Oques)
                                            .Include(p => p.Comos)
                                            .FirstOrDefault(p => p.Id == id);
            if (projeto is null)
            {
                return NotFound();
            }
            return Ok(projeto);
        }

        // Criar um novo projeto
        [HttpPost]
        public ActionResult<IEnumerable<Projeto>> Post(Projeto projeto)
        {
            if (projeto is null)
            {
                return BadRequest("Dados inválidos");
            }
            _context.Projeto.Add(projeto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = projeto.Id }, projeto);
        }


        // Adiciona um conceito a um projeto com base no seu id
        [HttpPost("{id}/conceito")]
        public ActionResult<IEnumerable<OQueAprender>> PostConeito(OQueAprender conceito, int id)
        {
            conceito.ProjetoId = id;
            _context.Oques.Add(conceito);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = conceito.Id }, conceito);
        }

        // Adiciona um fato a um projeto com base no seu id
        [HttpPost("{id}/fato")]
        public ActionResult<IEnumerable<OQueAprender>> PostFato(OQueAprender fato, int id)
        {
            fato.ProjetoId = id;
            _context.Oques.Add(fato);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = fato.Id }, fato);
        }

        // Adiciona um procedimento a um projeto com base no seu id
        [HttpPost("{id}/procedimento")]
        public ActionResult<IEnumerable<OQueAprender>> PostProcedimento(OQueAprender procedimento, int id)
        {
            procedimento.ProjetoId = id;
            _context.Oques.Add(procedimento);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = procedimento.Id }, procedimento);
        }

        // Atualizar um projeto 
        [HttpPut("{id:int}")]
        public ActionResult<IEnumerable<Projeto>> Put(int id, Projeto projeto)
        {
            if (id != projeto.Id)
            {
                return BadRequest("Dados inválidos");
            }
            _context.Entry(projeto).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(projeto);
        }

        // Deletar um projeto
        [HttpDelete("{id:int}")]
        public ActionResult<IEnumerable<Projeto>> Delete(int id)
        {
            var projeto = _context.Projeto.Find(id);
            if (projeto is null)
            {
                return NotFound();
            }
            _context.Projeto.Remove(projeto);
            _context.SaveChanges();
            return Ok(projeto);
        }
    }
}
