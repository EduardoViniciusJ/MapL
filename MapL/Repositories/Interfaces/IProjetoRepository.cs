using MapL.Models;

namespace MapL.Repositories.Interfaces
{
    public interface IProjetoRepository
    {
        IEnumerable<Projeto> GetAll();
        Projeto GetById(int id);
        Projeto Create(Projeto projeto);
        Projeto Update(Projeto projeto);
        Projeto Delete(int id);

        OQueAprender AddConceito(OQueAprender conceito, int id);
        OQueAprender AddFato(OQueAprender fato, int id);
        OQueAprender AddProcedimento(OQueAprender procedimento, int id);
    }
}
