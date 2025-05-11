using MapL.Context;
using MapL.Controllers;
using MapL.Models;
using MapL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MapL.Repositories
{
    public class PorqueAprenderRepository : IMotivacao
    {
        private readonly AppDbContext _context;

        public PorqueAprenderRepository(AppDbContext context)
        {
            _context = context;
        }

        public Motivacao Remover(int projetoId, int motivacaoId)
        {
            var motivacao = _context.Porques.AsNoTracking().FirstOrDefault(x => x.Id == motivacaoId && x.ProjetoId == projetoId);
            var motivacaoApagado = _context.Porques.Remove(motivacao);
            _context.SaveChanges();
            return motivacaoApagado.Entity;    

        }

        public IEnumerable<Motivacao> ObterTodas()
        {
            var motivacoes = _context.Porques.AsNoTracking().ToList();
            return motivacoes;
        }

        public Motivacao ObterPorId(int motivacaoId)
        {
            var motivacao = _context.Porques.AsNoTracking().FirstOrDefault(x => x.Id == motivacaoId);
            return motivacao;
        }

        public Motivacao ObterPorProjetoId(int projetoId)
        {
            var motivacao = _context.Porques.AsNoTracking().FirstOrDefault(x => x.ProjetoId == id);
            return motivacao;
        }

        public Motivacao Criar(Motivacao motivacao)
        {
            _context.Porques.Add(motivacao);
            _context.SaveChanges();
            return motivacao;
        }

        public Motivacao Atualizar(Motivacao motivacao, int motivacaoId, int projetoId)
        {
            var motivacaoExistente = _context.Porques.AsNoTracking().FirstOrDefault(x => x.Id == motivacaoId && x.ProjetoId == projetoId);

            motivacao.Id = motivacaoId;
            motivacao.ProjetoId = projetoId;

            _context.Porques.Update(motivacao);
            _context.SaveChanges();
            return motivacao;
        }
    }
}
