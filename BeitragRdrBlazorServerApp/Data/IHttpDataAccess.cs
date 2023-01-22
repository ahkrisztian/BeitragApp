using BeitragRdr.DTOs;

namespace BeitragRdrBlazorServerApp.Data
{
    public interface IHttpDataAccess
    {
        Task<IEnumerable<BeitragDTO>> Beitrags();
    }
}