using MapL.Context;
using MapL.Controllers;
using MapL.Models;
using MapL.Pagination;
using MapL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MapL.Repositories
{
    public class MotivacaoRepository : IMotivacaoRepository
    {
        private readonly AppDbContext _context;

        public MotivacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Motivacao>> ObterTodasAsync()
        {
            var motivacoes = await _context.Motivacoes.AsNoTracking().ToListAsync();
            return motivacoes;
        }

        public async Task<Motivacao> ObterPorIdAsync(int motivacaoId)
        {
            var motivacao = await _context.Motivacoes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == motivacaoId);
            return motivacao;
        }

        public async Task<IEnumerable<Motivacao>> ObterPorProjetoIdAsync(int projetoId)
        {
            var motivacao = await _context.Motivacoes.AsNoTracking().Where(x => x.ProjetoId == projetoId).ToListAsync();
            return motivacao;
        }

        public async Task<PagedList<Motivacao>> ObterPorPaginacaoAsync(QueryStringParameters motivacaoParams)
        {
            var motivacoesAsync = await ObterTodasAsync();

            var motivacoes = motivacoesAsync.OrderBy(x => x.Id).AsQueryable();

            var motivacoesOrdenadas = PagedList<Motivacao>.ToPagedList(motivacoes, motivacaoParams.PageNumber, motivacaoParams.PageSize);

            return motivacoesOrdenadas;
        }

        public Motivacao Criar(Motivacao motivacao)
        {
            _context.Motivacoes.Add(motivacao);
            return motivacao;
        }

        public Motivacao Atualizar(Motivacao motivacao, int motivacaoId, int projetoId)
        {
            var motivacaoExistente = _context.Motivacoes.AsNoTracking().FirstOrDefault(x => x.Id == motivacaoId && x.ProjetoId == projetoId);
            _context.Motivacoes.Update(motivacao);
            return motivacao;
        }

        public Motivacao Remover(int projetoId, int motivacaoId)
        {
            var motivacao = _context.Motivacoes.AsNoTracking().FirstOrDefault(x => x.Id == motivacaoId && x.ProjetoId == projetoId);
            var motivacaoApagado = _context.Motivacoes.Remove(motivacao);
            return motivacaoApagado.Entity;
        }
    }
}
