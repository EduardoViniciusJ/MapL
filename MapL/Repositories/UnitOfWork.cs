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
        
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
