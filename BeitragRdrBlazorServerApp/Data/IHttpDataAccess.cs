using BeitragRdr.DTOs;
using BeitragRdr.DTOs.CompanyDTOs;

namespace BeitragRdrBlazorServerApp.Data
{
    public interface IHttpDataAccess
    {
        Task<IEnumerable<BeitragDTO>> Beitrags();

        Task<BeitragDTO> BeitragById(int id);

        Task<BeitragDTO> CreateBeitrag(CreateBeitragDTO createBeitragDTO);

        Task<List<CompanyReadDTO>> Companies();
    }
}