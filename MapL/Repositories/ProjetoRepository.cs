using MapL.Context;
using MapL.Models;
using MapL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MapL.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly AppDbContext _context;

        public ProjetoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Projeto> GetAll()
        {
            return _context.Projeto.Include(p => p.Porques)
                                    .Include(p => p.Oques)
                                    .Include(p => p.Comos)
                                    .ToList();
        }

        public Projeto GetById(int id)
        {
            return _context.Projeto.Include(p => p.Porques)
                                    .Include(p => p.Oques)
                                    .Include(p => p.Comos)
                                    .FirstOrDefault(p => p.Id == id);
        }

        public Projeto Create(Projeto projeto)
        {
            _context.Projeto.Add(projeto);
            _context.SaveChanges();
            return projeto;
        }

        public Projeto Update(Projeto projeto)
        {
            _context.Projeto.Update(projeto);
            _context.SaveChanges();
            return projeto;
        }

        public Projeto Delete(int id)
        {
            var projeto = _context.Projeto.Find(id);
            _context.Projeto.Remove(projeto);
            _context.SaveChanges();
            return projeto;


        }

        public OQueAprender AddConceito(OQueAprender conceito, int id)
        {
            conceito.ProjetoId = id;
            _context.Oques.Add(conceito);
            _context.SaveChanges();
            return conceito;
        }

        public OQueAprender AddFato(OQueAprender fato, int id)
        {
            fato.ProjetoId = id;
            _context.Oques.Add(fato);
            _context.SaveChanges();
            return fato;
        }

        public OQueAprender AddProcedimento(OQueAprender procedimento, int id)
        {
            procedimento.ProjetoId = id;
            _context.Oques.Add(procedimento);
            _context.SaveChanges();
            return procedimento;
        }
    }
}
