using BeitragRdr.DTOs;
using BeitragRdr.DTOs.CompanyDTOs;
using BeitragRdr.Models;
using BeitragRdrBlazorServerApp.Policies;
using System.Collections.ObjectModel;
using System.Security.Policy;

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
    }
}
