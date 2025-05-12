using MapL.Context;
using MapL.Models;
using MapL.Pagination;
using MapL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MapL.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly AppDbContext _context;

        public ProjetoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Projeto> ObterTodas()
        {
            return _context.Projetos.Include(p => p.Motivacoes)
                                    .Include(p => p.Conhecimentos)
                                    .Include(p => p.Estrategias).AsNoTracking()
                                    .ToList();
        }

        public Projeto ObterPorId(int id)
        {
            return _context.Projetos.Include(p => p.Motivacoes)
                                    .Include(p => p.Conhecimentos)
                                    .Include(p => p.Estrategias).AsNoTracking()
                                    .FirstOrDefault(p => p.Id == id);
        }

        public Projeto Criar(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            return projeto;
        }

        public Projeto Atualizar(Projeto projeto)
        {
            _context.Projetos.Update(projeto);
            return projeto;
        }

        public Projeto Remover(int id)
        {
            var projeto = _context.Projetos.Find(id);
            _context.Projetos.Remove(projeto);
            return projeto;


        }

        public Projeto CriarProjetoCompleto(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            return projeto;
        }

        public PagedList<Projeto> ObterPorPaginacao(QueryStringParameters projetoParameters)
        {
            var projetos = ObterTodas().OrderBy(x => x.Id).AsQueryable();

            var projetoOrdenados = PagedList<Projeto>.ToPagedList(projetos, projetoParameters.PageNumber, projetoParameters.PageSize);  

            return projetoOrdenados;    
        }


    }
}
