using MapL.Context;
using MapL.Models;
using MapL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MapL.Repositories
{
    public class ComoAprenderRepository : IComoAprenderRepository
    {
        private readonly AppDbContext _context;

        public ComoAprenderRepository(AppDbContext context)
        {
            _context = context;
        }

        public ComoAprender ComoAprenderDelete(int projetoId, int id)
        {
            var comoAprender = _context.Comos.AsNoTracking().FirstOrDefault(x => x.Id == id && x.ProjetoId == projetoId);
            var comoAprenderApagado = _context.Comos.Remove(comoAprender);
            _context.SaveChanges();
           return comoAprenderApagado.Entity;
        }

        public IEnumerable<ComoAprender> ComoAprenderGet()
        {
            var comoAprender = _context.Comos.AsNoTracking().ToList();
            return comoAprender;
        }

        public ComoAprender ComoAprenderGetIdComo(int id)
        {
            var comoAprender = _context.Comos.AsNoTracking().FirstOrDefault(x => x.Id == id);    
            return comoAprender;
        }

        public ComoAprender ComoAprenderGetIdProjeto(int id)
        {
            var comoAprender = _context.Comos.AsNoTracking().FirstOrDefault(x => x.ProjetoId == id);
            return comoAprender;   
        }

        public ComoAprender ComoAprenderPost(ComoAprender comoAprender)
        {
            _context.Comos.Add(comoAprender);
            _context.SaveChanges();
            return comoAprender;
        }

        public ComoAprender ComoAprenderPut(ComoAprender comoAprender, int projetoId, int id)
        {
            var comoAprenderExistente = _context.Comos.AsNoTracking().FirstOrDefault(x => x.Id == id && x.ProjetoId == projetoId);

            comoAprender.Id = id;
            comoAprender.ProjetoId = projetoId;

            _context.Comos.Update(comoAprender);   
            _context.SaveChanges();
            return comoAprender;
        }

    }
}
