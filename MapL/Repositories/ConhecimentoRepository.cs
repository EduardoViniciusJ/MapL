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

        public IEnumerable<Conhecimento> ObterTodas()
        {
            var conhecimentos = _context.Conhecimentos.AsNoTracking().ToList();
            return conhecimentos;
        }

        public Conhecimento ObterPorId(int conhecimentoId)
        {
            var conhecimento = _context.Conhecimentos.AsNoTracking().FirstOrDefault(x => x.Id == conhecimentoId);
            return conhecimento;
        }

        public IEnumerable<Conhecimento> ObterPorProjetoId(int projetoId)
        {
            var conhecimento = _context.Conhecimentos.AsNoTracking().Where(x=> x.ProjetoId == projetoId).ToList();

            return conhecimento;
        }

        // Obter conhecimentos por paginação
        public PagedList<Conhecimento> ObterPorPaginacao(QueryStringParameters conhecimentosParams)
        {
            var conhecimentos = ObterTodas().OrderBy(x => x.Id).AsQueryable(); // Ordena os conhecimentos pelo ID.

            var conhecimentosOrdenados = PagedList<Conhecimento>.ToPagedList(conhecimentos,conhecimentosParams.PageNumber, conhecimentosParams.PageSize); // Define a paginação dos conhecimentos.

            return conhecimentosOrdenados;
        }
    }
}
