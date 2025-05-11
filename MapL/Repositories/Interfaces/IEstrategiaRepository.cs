using MapL.Models;

namespace MapL.Repositories.Interfaces
{
    public interface IEstrategiaRepository
    {
        IEnumerable<Estrategia> ObterTodas();
        IEnumerable<Estrategia> ObterPorProjetoId(int projetoId);
        Estrategia ObterPorId(int estrategiaId);
        Estrategia Criar(Estrategia estrategia);
        Estrategia Atualizar(Estrategia estrategia, int estrategiaId, int projetoId);
        Estrategia Remover(int estrategiaId, int projetoId);

    }
}
