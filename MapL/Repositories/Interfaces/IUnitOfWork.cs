namespace MapL.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IConhecimentoRepository Conhecimentos { get; }
        IEstrategiaRepository Estrategias { get; }
        IMotivacaoRepository Motivacoes { get; }
        IProjetoRepository Projetos { get; }
        int Commit();
    }
}
