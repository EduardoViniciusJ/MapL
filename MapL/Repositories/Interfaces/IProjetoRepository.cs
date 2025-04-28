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

        OQueAprender OQueAprender(OQueAprender oQueAprender, int id);
    }
}
