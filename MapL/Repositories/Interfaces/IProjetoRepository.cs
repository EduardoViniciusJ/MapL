using MapL.Models;
using MapL.Pagination;

namespace MapL.Repositories.Interfaces
{
    public interface IProjetoRepository
    {
        IEnumerable<Projeto> ObterTodas();
        Projeto ObterPorId(int id);
        Projeto Criar(Projeto projeto);
        Projeto Atualizar(Projeto projeto);
        Projeto Remover(int id);
        Projeto CriarProjetoCompleto(Projeto projeto); 
        PagedList<Projeto> ObterPorPaginacao(QueryStringParameters projetosParams);
    }
}
