using MapL.Context;
using MapL.Models;
using MapL.Pagination;
using MapL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MapL.Repositories
{
    public class ConhecimentoRepository : IConhecimentoRepository
    {
        private readonly AppDbContext _context;

        public ConhecimentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Conhecimento>> ObterTodasAsync()
        {
            var conhecimentos = await _context.Conhecimentos.AsNoTracking().ToListAsync();
            return conhecimentos;
        }

        public async Task<Conhecimento> ObterPorIdAsync(int conhecimentoId)
        {
            var conhecimento = await _context.Conhecimentos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == conhecimentoId);
            return conhecimento;
        }

        public async Task<IEnumerable<Conhecimento>> ObterPorProjetoIdAsync(int projetoId)
        {
            var conhecimento = await _context.Conhecimentos.AsNoTracking().Where(x => x.ProjetoId == projetoId).ToListAsync();
            return conhecimento;
        }

        public async Task<PagedList<Conhecimento>> ObterPorPaginacaoAsync(QueryStringParameters conhecimentosParams)
        {
            var conhecimentosAsync = await ObterTodasAsync();
            
            var conhecimentos = conhecimentosAsync.OrderBy(x => x.Id).AsQueryable();

            var conhecimentosOrdenados = PagedList<Conhecimento>.ToPagedList(conhecimentos, conhecimentosParams.PageNumber, conhecimentosParams.PageSize); 

            return conhecimentosOrdenados;
        }

        public Conhecimento Criar(Conhecimento conhecimento)
        {
            _context.Conhecimentos.Add(conhecimento);
            return conhecimento;
        }

        public Conhecimento Atualizar(Conhecimento conhecimento, int conhecimentoId, int projetoId)
        {
            var conhecimentoExistente = _context.Conhecimentos.AsNoTracking().FirstOrDefault(x => x.Id == conhecimentoId && x.ProjetoId == projetoId);

            conhecimento.Id = conhecimentoId;
            conhecimento.ProjetoId = projetoId;

            _context.Conhecimentos.Update(conhecimento);
            return conhecimento;
        }

        public Conhecimento Remover(int conhecimentoID, int projetoId)
        {
            var conhecimentoExistente = _context.Conhecimentos.FirstOrDefault(x => x.Id == conhecimentoID && x.ProjetoId == projetoId);

            var conhecimentoApagado = _context.Conhecimentos.Remove(conhecimentoExistente);
            return conhecimentoApagado.Entity;
        }
    }
}
