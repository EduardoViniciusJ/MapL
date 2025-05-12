using MapL.Models;
using MapL.Pagination;

namespace MapL.Repositories.Interfaces
{
    public interface IMotivacaoRepository
    {
        Task<IEnumerable<Motivacao>> ObterTodasAsync();
        Task<Motivacao> ObterPorIdAsync(int estrategiaId);
        Task<IEnumerable<Motivacao>> ObterPorProjetoIdAsync(int projetoId);
        Task<PagedList<Motivacao>> ObterPorPaginacaoAsync(QueryStringParameters motivacaoParams);
        Motivacao Criar(Motivacao porqueAprender);
        Motivacao Atualizar(Motivacao porqueAprender, int projetoId, int id);
        Motivacao Remover(int projetoId, int id);
    }
}
