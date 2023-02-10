using BeitragRdr.DTOs;
using BeitragRdr.DTOs.CompanyDTOs;
using BeitragRdr.Models;
using BeitragRdr.Models.UserModel;
using BeitragRdrBlazorServerApp.Policies;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;

namespace BeitragRdrBlazorServerApp.Data
{
    public class HttpDataAccess : IHttpDataAccess
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ClientPolicies policies;

        public HttpDataAccess(IHttpClientFactory httpClientFactory, ClientPolicies policies)
        {
            this.httpClientFactory = httpClientFactory;
            this.policies = policies;
        }

        public async Task<IEnumerable<BeitragDTO>> Beitrags()
        {
            var response = await policies.ImmediateHttpRetry.ExecuteAsync(
                        () => httpClientFactory.CreateClient("base").GetAsync("/api/v1/Beitrag/GetTheBeitrags"));

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<BeitragDTO>>();
        }

        public async Task<BeitragDTO> BeitragById(int id)
        {
            var response = await policies.ImmediateHttpRetry.ExecuteAsync(
                        () => httpClientFactory.CreateClient("base").GetAsync($"/api/v1/Beitrag/GetTheBeitragsByid/{id}"));

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<BeitragDTO>();
        }

        public async Task<BeitragDTO> CreateBeitrag(CreateBeitragDTO createBeitragDTO)
        {
            var response = await policies.ImmediateHttpRetry.ExecuteAsync(
                        () => httpClientFactory.CreateClient("base").PostAsJsonAsync("/api/v1/Beitrag/CreateBeitrag/", createBeitragDTO));

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<BeitragDTO>();

        }

        public async Task<List<CompanyReadDTO>> Companies()
        {
            var response = await policies.ImmediateHttpRetry.ExecuteAsync(
                        () => httpClientFactory.CreateClient("base").GetAsync($"/api/v1/Beitrag/GetCompanies/"));

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<CompanyReadDTO>>();
        }

        public async Task UpdateBeitrag(int id, BeitragDTO beitragDTO)
        {
            var response = await policies.ImmediateHttpRetry.ExecuteAsync(
                        () => httpClientFactory.CreateClient("base").PutAsJsonAsync($"/api/v1/Beitrag/UpdateBeitrag/{id}", beitragDTO));

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteBeitrag(int id)
        {
            var response = await policies.ImmediateHttpRetry.ExecuteAsync(
                        () => httpClientFactory.CreateClient("base").DeleteAsync($"/api/v1/Beitrag/DeleteBeitrag/{id}"));

            response.EnsureSuccessStatusCode();
        }

        public async Task PartialUpdateBeitrag(int id, JsonPatchDocument<BeitragDTO> patchDocument)
        {
            var serializedDoc = JsonConvert.SerializeObject(patchDocument);
            var requestContent = new StringContent(serializedDoc, Encoding.UTF8, "application/json-patch+json");

            var response = await policies.ImmediateHttpRetry.ExecuteAsync(
                        () => httpClientFactory.CreateClient("base").PatchAsync($"/api/v1/Beitrag/PartialBeitragUpdate/{id}", requestContent));

            response.EnsureSuccessStatusCode();
        }

        public async Task<UserReadDTO> GetUserByObjectId(string objectId)
        {
            var response = await policies.ImmediateHttpRetry.ExecuteAsync(
                        () => httpClientFactory.CreateClient("base").GetAsync($"/api/v1/User/GetUserByObjectId/{objectId}"));

            return await response.Content.ReadFromJsonAsync<UserReadDTO>();
        }

        public async Task<UserReadDTO> CreateUser(UserCreateDTO createUser)
        {
            var response = await policies.ImmediateHttpRetry.ExecuteAsync(
                        () => httpClientFactory.CreateClient("base").PostAsJsonAsync("/api/v1/User/CreateUser/", createUser));

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<UserReadDTO>();

        }
    }
}
