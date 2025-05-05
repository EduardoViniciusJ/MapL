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
                                    .Include(p => p.Comos).AsNoTracking()
                                    .ToList();
        }

        public Projeto GetById(int id)
        {
            return _context.Projeto.Include(p => p.Porques)
                                    .Include(p => p.Oques)
                                    .Include(p => p.Comos).AsNoTracking()
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
    }
}
