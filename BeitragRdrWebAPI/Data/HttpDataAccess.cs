namespace BeitragRdrWebAPI.Data
{
    public class HttpDataAccess
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ClientPolicies policies;

        public HttpDataAccess(IHttpClientFactory httpClientFactory, ClientPolicies policies)
        {
            this.httpClientFactory = httpClientFactory;
            this.policies = policies;
        }
    }
}
