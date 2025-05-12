using MapL.Models;
using MapL.Pagination;

namespace MapL.Repositories.Interfaces
{
    public interface IConhecimentoRepository
    {
        IEnumerable<Conhecimento> ObterTodas();    
        IEnumerable<Conhecimento> ObterPorProjetoId(int projetoId);    
        Conhecimento ObterPorId(int conhecimentoId);    
        Conhecimento Criar(Conhecimento conhecimento);
        Conhecimento Atualizar(Conhecimento conhecimento, int conhecimentoId, int projetoId);
        Conhecimento Remover(int conhecimentoId, int projetoId);
        PagedList<Conhecimento> ObterPorPaginacao(QueryStringParameters conhecimentosParams);

    }
}
