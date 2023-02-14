using BeitragRdr.Models;
using BeitragRdr.Models.CompanyModel;

namespace BeitragRdrDataAccessLibrary.Repo
{
    public interface IBeitragRepo
    {
        Task CreateBeitrag(Beitrag beitrag);
        void DeleteBeitrag(int id);
        Task<IEnumerable<Beitrag>> GetAllBeitragsAsync();
        Task<Beitrag> GetBeitragById(int id);

        Task<List<Beitrag>> GetBeitragByUserId(int id);
        void UpdateBeitrag(Beitrag beitrag);

        Task<List<Company>> Companies();
    }
}