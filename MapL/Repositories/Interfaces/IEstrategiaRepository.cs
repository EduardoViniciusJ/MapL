using MapL.Models;
using MapL.Pagination;

namespace MapL.Repositories.Interfaces
{
    public interface IEstrategiaRepository
    {
        Task<IEnumerable<Estrategia>> ObterTodasAsync();
        Task<IEnumerable<Estrategia>> ObterPorProjetoIdAsync(int projetoId);
        Task<Estrategia> ObterPorIdAsync(int estrategiaId);
        Task<PagedList<Estrategia>> ObterPorPaginacaoAsync(QueryStringParameters estrategiasParams);
        Estrategia Criar(Estrategia estrategia);
        Estrategia Atualizar(Estrategia estrategia, int estrategiaId, int projetoId);
        Estrategia Remover(int estrategiaId, int projetoId);

    }
}
