using MapL.Models;

namespace MapL.Repositories.Interfaces
{
    public interface IComoAprenderRepository
    {
        IEnumerable<ComoAprender> ComoAprenderGet(); 
        ComoAprender ComoAprenderGetIdProjeto(int id);
        ComoAprender ComoAprenderGetIdComo(int id);
        ComoAprender ComoAprenderPost(ComoAprender comoAprender);
        ComoAprender ComoAprenderPut(ComoAprender comoAprender, int projetoId, int id);
        ComoAprender ComoAprenderDelete(int projetoId, int id);

    }
}
