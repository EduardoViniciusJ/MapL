using MapL.Models;

namespace MapL.Repositories.Interfaces
{
    public interface IPorqueAprenderRepository
    {
        IEnumerable<PorqueAprender> PorqueAprenderGet();
        PorqueAprender PorqueAprenderGetIdProjeto(int id);
        PorqueAprender PorqueAprenderGetIdPorque(int id);
        PorqueAprender PorqueAprenderPost(PorqueAprender porqueAprender);
        PorqueAprender PorqueAprenderPut(PorqueAprender porqueAprender);
        PorqueAprender PorqueAprenderDelete(int projetoId, int id);

    }
}
