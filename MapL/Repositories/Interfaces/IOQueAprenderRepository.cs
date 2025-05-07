using MapL.Models;

namespace MapL.Repositories.Interfaces
{
    public interface IOQueAprenderRepository
    {
        IEnumerable<OQueAprender> OQueAprenderGet();    
        IEnumerable<OQueAprender> OQueAprenderGetByIdProjeto(int id);    
        OQueAprender OQueAprenderGetByIdOque(int id);    
        OQueAprender OQueAprenderPost(OQueAprender oQueAprender);
        OQueAprender OQueAprenderPut(OQueAprender oQueAprender);
        OQueAprender OQueAprenderDelete(int projetoId, int id);

    }
}
