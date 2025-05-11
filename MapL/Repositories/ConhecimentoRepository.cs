using MapL.Context;
using MapL.Models;
using MapL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MapL.Repositories
{
    public class ConhecimentoRepository : IConhecimentoRepository
            {
        private readonly AppDbContext _context;

        public ConhecimentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public Conhecimento Criar(Conhecimento conhecimento)
        {
            _context.Oques.Add(conhecimento);
            _context.SaveChanges();
            return conhecimento;
        }

        public Conhecimento Atualizar(Conhecimento conhecimento, int conhecimentoId, int projetoId)
        {
            var conhecimentoExistente = _context.Oques.AsNoTracking().FirstOrDefault(x => x.Id == conhecimentoId && x.ProjetoId == projetoId);

            conhecimento.Id = conhecimentoId;
            conhecimento.ProjetoId = projetoId;    

            _context.Oques.Update(conhecimento);
            _context.SaveChanges();
            return conhecimento;
        }

        public Conhecimento OQueAprenderDelete(int projetoId, int id)
        {
            var oQueAprenderExistente = _context.Oques.FirstOrDefault(x => x.Id == id && x.ProjetoId == projetoId);

            var OQueAprenderApagado = _context.Oques.Remove(oQueAprenderExistente);
            _context.SaveChanges();
            return OQueAprenderApagado.Entity;
        }

        public IEnumerable<Conhecimento> OQueAprenderGet()
        {
            var oQueAprender = _context.Oques.AsNoTracking().ToList();
            return oQueAprender;
        }

        public Conhecimento OQueAprenderGetByIdOque(int id)
        {
            var oQueAprender = _context.Oques.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return oQueAprender;
        }

        public IEnumerable<Conhecimento> OQueAprenderGetByIdProjeto(int id)
        {
            var oQueAprender = _context.Oques.AsNoTracking().Where(x=> x.ProjetoId == id).ToList();

            return oQueAprender;
        }

    }
}
