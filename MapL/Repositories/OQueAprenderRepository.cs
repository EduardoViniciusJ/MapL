using MapL.Context;
using MapL.Models;
using MapL.Repositories.Interfaces;

namespace MapL.Repositories
{
    public class OQueAprenderRepository : IOQueAprenderRepository
            {
        private readonly AppDbContext _context;

        public OQueAprenderRepository(AppDbContext context)
        {
            _context = context;
        }

        public OQueAprender OQueAprenderPost(OQueAprender oQueAprender, int id)
        {
            oQueAprender.ProjetoId = id;
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

        public OQueAprender OQueAprenderDelete(OQueAprender oQueAprender)
        {
            var oQueAprenderExistente = _context.Oques.FirstOrDefault(x => x.Id == oQueAprender.Id);

            var OQueAprenderApagado = _context.Oques.Remove(oQueAprenderExistente);
            _context.SaveChanges();
            return OQueAprenderApagado.Entity;

        }


    }
}
