using MapL.Context;
using MapL.Models;
using MapL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MapL.Repositories
{
    public class EstrategiaRepository : IEstrategiaRepository
    {
        private readonly AppDbContext _context;

        public EstrategiaRepository(AppDbContext context)
        {
            _context = context;
        }

        // Obter todas as estratégias
        public IEnumerable<Estrategia> ObterTodas()
        {
            var estrategias = _context.Comos.AsNoTracking().ToList();
            return estrategias;
        }

        // Obter estratégia por Id
        public Estrategia ObterPorId(int estrategiaId)
        {
            var estrategia = _context.Comos.AsNoTracking().FirstOrDefault(x => x.Id == estrategiaId);
            return estrategia;
        }

        // Obter estratégia por Id do projeto
        public Estrategia ObterPorProjetoId(int projetoId)
        {
            var estrategia = _context.Comos.AsNoTracking().FirstOrDefault(x => x.ProjetoId == projetoId);
            return estrategia;
        }

        // Criar uma nova estratégia
        public Estrategia Criar(Estrategia estrategia)
        {
            _context.Comos.Add(estrategia);
            _context.SaveChanges();
            return estrategia;
        }

        // Atualizar uma estratégia 
        public Estrategia Atualizar(Estrategia estrategia, int projetoId, int estrategiaId)
        {
            var estrategiaExistente = _context.Comos.AsNoTracking().FirstOrDefault(x => x.Id == estrategiaId && x.ProjetoId == projetoId);

            if(estrategiaExistente == null)
            {
                throw new Exception("Estratégia não encontrada");
            }

            estrategia.Id = estrategiaId;
            estrategia.ProjetoId = projetoId;

            _context.Comos.Update(estrategia);
            _context.SaveChanges();
            return estrategia;
        }

        // Remove uma estratégia
        public Estrategia Remover(int estrategiaId, int projetoId)
        {
            var estrategia = _context.Comos.AsNoTracking().FirstOrDefault(x => x.Id == estrategiaId && x.ProjetoId == projetoId);
            if(estrategia == null)
            {
                throw new Exception("Estratégia não encontrada");
            }
            var estrategiaRemovido = _context.Comos.Remove(estrategia);
            _context.SaveChanges();
           return estrategiaRemovido.Entity;
        }
    }
}
