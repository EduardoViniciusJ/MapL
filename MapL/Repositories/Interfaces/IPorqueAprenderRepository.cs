using MapL.Models;

namespace MapL.Repositories.Interfaces
{
    public interface IPorqueAprenderRepository
    {
        IEnumerable<PorqueAprender> PorqueAprenderGet();
        PorqueAprender PorqueAprenderGetIdProjeto(int id);
        PorqueAprender PorqueAprenderGetIdPorque(int id);
        PorqueAprender PorqueAprenderPost(PorqueAprender porqueAprender);
        PorqueAprender PorqueAprenderPut(PorqueAprender porqueAprender, int projetoId, int id);
        PorqueAprender PorqueAprenderDelete(int projetoId, int id);

    }
}
