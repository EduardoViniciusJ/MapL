using MapL.Context;
using MapL.Controllers;
using MapL.Models;
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

        public Motivacao Remover(int projetoId, int motivacaoId)
        {
            var motivacao = _context.Motivacoes.AsNoTracking().FirstOrDefault(x => x.Id == motivacaoId && x.ProjetoId == projetoId);
            var motivacaoApagado = _context.Motivacoes.Remove(motivacao);
            return motivacaoApagado.Entity;    

        }

        public IEnumerable<Motivacao> ObterTodas()
        {
            var motivacoes = _context.Motivacoes.AsNoTracking().ToList();
            return motivacoes;
        }

        public Motivacao ObterPorId(int motivacaoId)
        {
            var motivacao = _context.Motivacoes.AsNoTracking().FirstOrDefault(x => x.Id == motivacaoId);
            return motivacao;
        }

        public IEnumerable<Motivacao> ObterPorProjetoId(int projetoId)
        {
            var motivacao = _context.Motivacoes.AsNoTracking().Where(x => x.ProjetoId == projetoId).ToList();
            return motivacao;
        }

        public Motivacao Criar(Motivacao motivacao)
        {
            _context.Motivacoes.Add(motivacao);
            return motivacao;
        }

        public Motivacao Atualizar(Motivacao motivacao, int motivacaoId, int projetoId)
        {
            var motivacaoExistente = _context.Motivacoes.AsNoTracking().FirstOrDefault(x => x.Id == motivacaoId && x.ProjetoId == projetoId);

            motivacao.Id = motivacaoId;
            motivacao.ProjetoId = projetoId;

            _context.Motivacoes.Update(motivacao);
            return motivacao;
        }
    }
}
