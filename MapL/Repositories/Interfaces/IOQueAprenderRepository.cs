using MapL.Models;

namespace MapL.Repositories.Interfaces
{
    public interface IOQueAprenderRepository
    {
        IEnumerable<OQueAprender> OQueAprenderGet();    
        IEnumerable<OQueAprender> OQueAprenderByIdProjeto(int id);    
        OQueAprender OQueAprenderGetByIdOque(int id);    
        OQueAprender OQueAprenderPost(OQueAprender oQueAprender);
        OQueAprender OQueAprenderPut(OQueAprender oQueAprender);
        OQueAprender OQueAprenderDelete(OQueAprender oQueAprender);

    }
}
