using MapL.Context;
using MapL.Models;
using MapL.Pagination;
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
            var estrategias = _context.Estrategias.AsNoTracking().ToList();
            return estrategias;
        }

        // Obter estratégia por Id
        public Estrategia ObterPorId(int estrategiaId)
        {
            var estrategia = _context.Estrategias.AsNoTracking().FirstOrDefault(x => x.Id == estrategiaId);
            return estrategia;
        }

        // Obter estratégias por Id do projeto
        public IEnumerable<Estrategia> ObterPorProjetoId(int projetoId)
        {
            var estrategia = _context.Estrategias.AsNoTracking().Where(x => x.ProjetoId == projetoId).ToList();
            return estrategia;
        }

        // Criar uma nova estratégia
        public Estrategia Criar(Estrategia estrategia)
        {
            _context.Estrategias.Add(estrategia);
            return estrategia;
        }

        // Atualizar uma estratégia 
        public Estrategia Atualizar(Estrategia estrategia, int projetoId, int estrategiaId)
        {
            var estrategiaExistente = _context.Estrategias.AsNoTracking().FirstOrDefault(x => x.Id == estrategiaId && x.ProjetoId == projetoId);

            if(estrategiaExistente == null)
            {
                throw new Exception("Estratégia não encontrada");
            }

            estrategia.Id = estrategiaId;
            estrategia.ProjetoId = projetoId;

            _context.Estrategias.Update(estrategia);
            return estrategia;
        }

        // Remove uma estratégia
        public Estrategia Remover(int estrategiaId, int projetoId)
        {
            var estrategia = _context.Estrategias.AsNoTracking().FirstOrDefault(x => x.Id == estrategiaId && x.ProjetoId == projetoId);
            if(estrategia == null)
            {
                throw new Exception("Estratégia não encontrada");
            }
            var estrategiaRemovido = _context.Estrategias.Remove(estrategia);
           return estrategiaRemovido.Entity;
        }

        // Obter estrategias por paginação
        public PagedList<Estrategia> ObterPorPaginacao(QueryStringParameters estrategiasParams)
        {
            var estrategias = ObterTodas().OrderBy(x => x.Id).AsQueryable();

            var estrategiasOrdenadas =  PagedList<Estrategia>.ToPagedList(estrategias, estrategiasParams.PageNumber, estrategiasParams.PageSize);

            return estrategiasOrdenadas;

        }
    }
}
