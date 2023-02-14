using AutoMapper;
using BeitragRdr.DTOs;
using BeitragRdr.DTOs.CompanyDTOs;
using BeitragRdr.Models;
using BeitragRdr.Models.UserModel;
using BeitragRdrDataAccessLibrary.Data;
using BeitragRdrDataAccessLibrary.Repo;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace BeitragRdrBlazorServerApp.Data
{
    public class DataAccess : IDataAccess
    {
        private readonly IBeitragRepo beitragRepo;
        private readonly IUserRepo userRepo;
        private readonly IMapper mapper;

        public DataAccess(IBeitragRepo beitragRepo, IUserRepo userRepo, IMapper mapper)
        {
            this.beitragRepo = beitragRepo;
            this.userRepo = userRepo;
            this.mapper = mapper;
        }
        public async Task<BeitragDTO> BeitragById(int id)
        {
            var output = await beitragRepo.GetBeitragById(id);

            return mapper.Map<BeitragDTO>(output);
        }

        public async Task<IEnumerable<BeitragDTO>> Beitrags()
        {
            var output = await beitragRepo.GetAllBeitragsAsync();

            return mapper.Map<IEnumerable<BeitragDTO>>(output);
        }

        public async Task<List<CompanyReadDTO>> Companies()
        {
            var output = await beitragRepo.Companies();

            return mapper.Map<List<CompanyReadDTO>>(output);
        }

        public async Task CreateBeitrag(CreateBeitragDTO createBeitragDTO)
        {
            await beitragRepo.CreateBeitrag(mapper.Map<Beitrag>(createBeitragDTO));
        }

        public void CreateUser(UserCreateDTO createUser)
        {
            userRepo.CreateUser(mapper.Map<User>(createUser));
        }

        public void DeleteBeitrag(int id)
        {
            beitragRepo.DeleteBeitrag(id);
        }

        public async Task<UserReadDTO> GetUserByObjectId(string objectId)
        {
            var output = await userRepo.GetUser(objectId);

            return mapper.Map<UserReadDTO>(output);
        }

        public Task PartialUpdateBeitrag(int id, JsonPatchDocument<BeitragDTO> patchDocument)
        {
            throw new NotImplementedException();
        }

        public void UpdateBeitrag(int id, BeitragDTO beitragDTO)
        {
            beitragRepo.UpdateBeitrag(mapper.Map<Beitrag>(beitragDTO));
        }
    }
}
