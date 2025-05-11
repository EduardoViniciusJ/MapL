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

        public IEnumerable<Projeto> ObterTodas()
        {
            return _context.Projeto.Include(p => p.Motivacoes)
                                    .Include(p => p.Conhecimentos)
                                    .Include(p => p.Estrategias).AsNoTracking()
                                    .ToList();
        }

        public Projeto ObterPorId(int id)
        {
            return _context.Projeto.Include(p => p.Motivacoes)
                                    .Include(p => p.Conhecimentos)
                                    .Include(p => p.Estrategias).AsNoTracking()
                                    .FirstOrDefault(p => p.Id == id);
        }

        public Projeto Criar(Projeto projeto)
        {
            _context.Projeto.Add(projeto);
            _context.SaveChanges();
            return projeto;
        }

        public Projeto Atualizar(Projeto projeto)
        {
            _context.Projeto.Update(projeto);
            _context.SaveChanges();
            return projeto;
        }

        public Projeto Remover(int id)
        {
            var projeto = _context.Projeto.Find(id);
            _context.Projeto.Remove(projeto);
            _context.SaveChanges();
            return projeto;


        }

        public Projeto CriarProjetoCompleto(Projeto projeto)
        {
            _context.Projeto.Add(projeto);
            _context.SaveChanges();
            return projeto;
        }
    }
}
