using BeitragRdr.Models.UserModel;

namespace BeitragRdrDataAccessLibrary.Repo
{
    public interface IUserRepo
    {
        Task<User> GetUser(string objectId);

        void CreateUser(User user);
    }
}