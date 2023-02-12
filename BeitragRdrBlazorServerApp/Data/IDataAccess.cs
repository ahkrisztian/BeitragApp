using BeitragRdr.DTOs;
using BeitragRdr.DTOs.CompanyDTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace BeitragRdrBlazorServerApp.Data
{
    public interface IDataAccess
    {
        Task<BeitragDTO> BeitragById(int id);
        Task<IEnumerable<BeitragDTO>> Beitrags();
        Task<List<CompanyReadDTO>> Companies();
        void CreateBeitrag(CreateBeitragDTO createBeitragDTO);
        void CreateUser(UserCreateDTO createUser);
        void DeleteBeitrag(int id);
        Task<UserReadDTO> GetUserByObjectId(string objectId);
        Task PartialUpdateBeitrag(int id, JsonPatchDocument<BeitragDTO> patchDocument);
        void UpdateBeitrag(int id, BeitragDTO beitragDTO);
    }
}