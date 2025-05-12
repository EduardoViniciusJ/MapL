using MapL.Models;
using MapL.Pagination;

namespace MapL.Repositories.Interfaces
{
    public interface IConhecimentoRepository
    {
        Task<IEnumerable<Conhecimento>> ObterTodasAsync();
        Task<Conhecimento> ObterPorIdAsync(int conhecimentoId);
        Task<IEnumerable<Conhecimento>> ObterPorProjetoIdAsync(int projetoId);
        Task<PagedList<Conhecimento>> ObterPorPaginacaoAsync(QueryStringParameters conhecimentosParams);
        Conhecimento Criar(Conhecimento conhecimento);
        Conhecimento Atualizar(Conhecimento conhecimento, int conhecimentoId, int projetoId);
        Conhecimento Remover(int conhecimentoId, int projetoId);

    }
}
