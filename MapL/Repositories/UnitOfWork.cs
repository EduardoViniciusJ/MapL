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

        public UnitOfWork(AppDbContext context, IMotivacaoRepository motivacaoRepo, IEstrategiaRepository estrategiaRepo, IConhecimentoRepository conhecimentoRepo, IProjetoRepository projetoRepo)
        {
            _context = context;
            Motivacoes = motivacaoRepo;
            Estrategias = estrategiaRepo;
            Conhecimentos = conhecimentoRepo;
            Projetos = projetoRepo;
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
