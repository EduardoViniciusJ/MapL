using MapL.Context;
using MapL.Models;
using MapL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MapL.Repositories
{
    public class OQueAprenderRepository : IOQueAprenderRepository
            {
        private readonly AppDbContext _context;

        public OQueAprenderRepository(AppDbContext context)
        {
            _context = context;
        }

        public OQueAprender OQueAprenderPost(OQueAprender oQueAprender)
        {
            _context.Oques.Add(oQueAprender);
            _context.SaveChanges();
            return oQueAprender;
        }

        public OQueAprender OQueAprenderPut(OQueAprender oQueAprender)
        {
            var oQueAprenderExistente = _context.Oques.FirstOrDefault(x => x.Id == oQueAprender.Id);

            oQueAprenderExistente.Conceito = oQueAprender.Conceito;
            oQueAprenderExistente.Fato = oQueAprender.Fato;
            oQueAprenderExistente.Procedimento = oQueAprender.Procedimento;

            _context.SaveChanges();
            return oQueAprenderExistente;
        }

        public OQueAprender OQueAprenderDelete(int projetoId, int id)
        {
            var oQueAprenderExistente = _context.Oques.FirstOrDefault(x => x.Id == id && x.ProjetoId == projetoId);

            var OQueAprenderApagado = _context.Oques.Remove(oQueAprenderExistente);
            _context.SaveChanges();
            return OQueAprenderApagado.Entity;
        }

        public IEnumerable<OQueAprender> OQueAprenderGet()
        {
            var oQueAprender = _context.Oques.AsNoTracking().ToList();
            return oQueAprender;
        }

        public OQueAprender OQueAprenderGetByIdOque(int id)
        {
            var oQueAprender = _context.Oques.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return oQueAprender;
        }

        public IEnumerable<OQueAprender> OQueAprenderGetByIdProjeto(int id)
        {
            var oQueAprender = _context.Oques.AsNoTracking().Where(x=> x.ProjetoId == id).ToList();

            return oQueAprender;
        }

    }
}
