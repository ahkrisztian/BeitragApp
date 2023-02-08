using BeitragRdr.DTOs;
using BeitragRdr.DTOs.CompanyDTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace BeitragRdrBlazorServerApp.Data
{
    public interface IHttpDataAccess
    {
        Task<IEnumerable<BeitragDTO>> Beitrags();

        Task<BeitragDTO> BeitragById(int id);

        Task<BeitragDTO> CreateBeitrag(CreateBeitragDTO createBeitragDTO);

        Task<List<CompanyReadDTO>> Companies();

        Task UpdateBeitrag(int id, BeitragDTO beitragDTO);

        Task DeleteBeitrag(int id);

        Task PartialUpdateBeitrag(int id, JsonPatchDocument<BeitragDTO> patchDocument);
    }
}