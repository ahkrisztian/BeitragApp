using BeitragRdr.DTOs;
using BeitragRdr.Models.UserModel;
using Microsoft.AspNetCore.Components.Authorization;

namespace BeitragRdrBlazorServerApp.Data
{
    public static class AuthenticationStateProviderHelper
    {
        public static async Task<UserReadDTO> GetUserFromAuth(
                            this AuthenticationStateProvider provider,
                            IHttpDataAccess dataAccess)
        {
            var authState = await provider.GetAuthenticationStateAsync();
            string objectId = authState.User.Claims.FirstOrDefault(c => c.Type.Contains("objectidentifier"))?.Value;
            return await dataAccess.GetUserByObjectId(objectId);
        }
    }
}
