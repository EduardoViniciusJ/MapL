using MapL.Models;

namespace MapL.Repositories.Interfaces
{
    public interface IOQueAprenderRepository
    {
        OQueAprender OQueAprenderPost(OQueAprender oQueAprender, int id);
        OQueAprender OQueAprenderPut(OQueAprender oQueAprender);
        OQueAprender OQueAprenderDelete(OQueAprender oQueAprender);

    }
}
