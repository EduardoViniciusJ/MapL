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

        public PorqueAprender PorqueAprenderDelete(int projetoId, int id)
        {
            var porqueAprender = _context.Porques.AsNoTracking().FirstOrDefault(x => x.Id == id && x.ProjetoId == projetoId);
            var porqueAprenderApagado = _context.Porques.Remove(porqueAprender);
            _context.SaveChanges();
            return porqueAprenderApagado.Entity;    

        }

        public IEnumerable<PorqueAprender> PorqueAprenderGet()
        {
            var porqueAprender = _context.Porques.AsNoTracking().ToList();
            return porqueAprender;
        }

        public PorqueAprender PorqueAprenderGetIdPorque(int id)
        {
            var porqueAprender = _context.Porques.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return porqueAprender;
        }

        public PorqueAprender PorqueAprenderGetIdProjeto(int id)
        {
            var porqueAprender = _context.Porques.AsNoTracking().FirstOrDefault(x => x.ProjetoId == id);
            return porqueAprender;
        }

        public PorqueAprender PorqueAprenderPost(PorqueAprender porqueAprender)
        {
            _context.Porques.Add(porqueAprender);
            _context.SaveChanges();
            return porqueAprender;
        }

        public PorqueAprender PorqueAprenderPut(PorqueAprender porqueAprender)
        {
            var porqueAprenderExistente = _context.Porques.FirstOrDefault(x => x.Id == porqueAprender.Id);
            porqueAprenderExistente.Texto = porqueAprender.Texto;   
            _context.SaveChanges();
            return porqueAprenderExistente;
        }
    }
}
