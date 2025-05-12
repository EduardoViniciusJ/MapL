using MapL.Models;
using MapL.Pagination;

namespace MapL.Repositories.Interfaces
{
    public interface IProjetoRepository
    {
        Task<IEnumerable<Projeto>> ObterTodasAsync();
        Task<Projeto> ObterPorIdAsync(int id);
        Task<PagedList<Projeto>> ObterPorPaginacaoAsync(QueryStringParameters projetosParams);
        Projeto Criar(Projeto projeto);
        Projeto CriarProjetoCompleto(Projeto projeto);
        Projeto Atualizar(Projeto projeto);
        Projeto Remover(int id);
    }
}
