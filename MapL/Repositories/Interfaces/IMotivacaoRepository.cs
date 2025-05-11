using MapL.Models;

namespace MapL.Repositories.Interfaces
{
    public interface IMotivacaoRepository
    {
        IEnumerable<Motivacao> ObterTodas();
        IEnumerable<Motivacao> ObterPorProjetoId(int projetoId);
        Motivacao ObterPorId(int estrategiaId);
        Motivacao Criar(Motivacao porqueAprender);
        Motivacao Atualizar(Motivacao porqueAprender, int projetoId, int id);
        Motivacao Remover(int projetoId, int id);
    }
}
