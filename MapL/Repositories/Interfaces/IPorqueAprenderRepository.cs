using MapL.Models;

namespace MapL.Repositories.Interfaces
{
    public interface IPorqueAprenderRepository
    {
        IEnumerable<Motivacao> PorqueAprenderGet();
        Motivacao PorqueAprenderGetIdProjeto(int id);
        Motivacao PorqueAprenderGetIdPorque(int id);
        Motivacao PorqueAprenderPost(Motivacao porqueAprender);
        Motivacao PorqueAprenderPut(Motivacao porqueAprender, int projetoId, int id);
        Motivacao PorqueAprenderDelete(int projetoId, int id);

    }
}
