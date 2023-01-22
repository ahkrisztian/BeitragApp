﻿using BeitragRdr.DTOs;
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
    }
}
