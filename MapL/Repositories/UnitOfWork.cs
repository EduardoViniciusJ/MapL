using MapL.Context;
using MapL.Models;
using MapL.Repositories.Interfaces;

namespace MapL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IMotivacaoRepository Motivacoes { get; }
        public IEstrategiaRepository Estrategias { get; }
        public IConhecimentoRepository Conhecimentos { get; }
        public IProjetoRepository Projetos { get; }   

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Motivacoes = new MotivacaoRepository(_context);
            Estrategias = new EstrategiaRepository(_context);
            Conhecimentos = new ConhecimentoRepository(_context);
            Projetos = new ProjetoRepository(_context);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
