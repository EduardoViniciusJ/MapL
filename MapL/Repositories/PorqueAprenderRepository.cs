using MapL.Context;
using MapL.Controllers;
using MapL.Models;
using MapL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MapL.Repositories
{
    public class PorqueAprenderRepository : IPorqueAprenderRepository
    {
        private readonly AppDbContext _context;

        public PorqueAprenderRepository(AppDbContext context)
        {
            _context = context;
        }

        public Motivacao PorqueAprenderDelete(int projetoId, int id)
        {
            var porqueAprender = _context.Porques.AsNoTracking().FirstOrDefault(x => x.Id == id && x.ProjetoId == projetoId);
            var porqueAprenderApagado = _context.Porques.Remove(porqueAprender);
            _context.SaveChanges();
            return porqueAprenderApagado.Entity;    

        }

        public IEnumerable<Motivacao> PorqueAprenderGet()
        {
            var porqueAprender = _context.Porques.AsNoTracking().ToList();
            return porqueAprender;
        }

        public Motivacao PorqueAprenderGetIdPorque(int id)
        {
            var porqueAprender = _context.Porques.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return porqueAprender;
        }

        public Motivacao PorqueAprenderGetIdProjeto(int id)
        {
            var porqueAprender = _context.Porques.AsNoTracking().FirstOrDefault(x => x.ProjetoId == id);
            return porqueAprender;
        }

        public Motivacao PorqueAprenderPost(Motivacao porqueAprender)
        {
            _context.Porques.Add(porqueAprender);
            _context.SaveChanges();
            return porqueAprender;
        }

        public Motivacao PorqueAprenderPut(Motivacao porqueAprender, int projetoId, int id)
        {
            var porqueAprenderExistente = _context.Porques.AsNoTracking().FirstOrDefault(x => x.Id == id && x.ProjetoId == projetoId);

            porqueAprender.Id = id;
            porqueAprender.ProjetoId = projetoId;

            _context.Porques.Update(porqueAprender);
            _context.SaveChanges();
            return porqueAprender;
        }
    }
}
