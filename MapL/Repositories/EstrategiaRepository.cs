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

        public async Task<IEnumerable<Estrategia>> ObterTodasAsync()
        {
            var estrategias = await _context.Estrategias.AsNoTracking().ToListAsync();
            return estrategias;
        }

        public async Task<Estrategia> ObterPorIdAsync(int estrategiaId)
        {
            var estrategia = await _context.Estrategias.AsNoTracking().FirstOrDefaultAsync(x => x.Id == estrategiaId);
            return estrategia;
        }

        public async Task<IEnumerable<Estrategia>> ObterPorProjetoIdAsync(int projetoId)
        {
            var estrategia = await _context.Estrategias.AsNoTracking().Where(x => x.ProjetoId == projetoId).ToListAsync();
            return estrategia;
        }

        public async Task<PagedList<Estrategia>> ObterPorPaginacaoAsync(QueryStringParameters estrategiasParams)
        {
            var estrategiasAsync = await ObterTodasAsync();

            var estrategias = estrategiasAsync.OrderBy(x => x.Id).AsQueryable();

            var estrategiasOrdenadas = PagedList<Estrategia>.ToPagedList(estrategias, estrategiasParams.PageNumber, estrategiasParams.PageSize);

            return estrategiasOrdenadas;
        }

        public Estrategia Criar(Estrategia estrategia)
        {
            _context.Estrategias.Add(estrategia);
            return estrategia;
        }

        public Estrategia Atualizar(Estrategia estrategia, int projetoId, int estrategiaId)
        {
            var estrategiaExistente = _context.Estrategias.AsNoTracking().FirstOrDefault(x => x.Id == estrategiaId && x.ProjetoId == projetoId);

            if (estrategiaExistente == null)
            {
                throw new Exception("Estratégia não encontrada");
            }

            estrategia.Id = estrategiaId;
            estrategia.ProjetoId = projetoId;

            _context.Estrategias.Update(estrategia);
            return estrategia;
        }

        public Estrategia Remover(int estrategiaId, int projetoId)
        {
            var estrategia = _context.Estrategias.AsNoTracking().FirstOrDefault(x => x.Id == estrategiaId && x.ProjetoId == projetoId);
            if (estrategia == null)
            {
                throw new Exception("Estratégia não encontrada");
            }
            var estrategiaRemovido = _context.Estrategias.Remove(estrategia);
            return estrategiaRemovido.Entity;
        }
    }
}
