using BeitragRdr.DTOs;
using BeitragRdr.DTOs.CompanyDTOs;
using BeitragRdr.Models.UserModel;
using BeitragRdrBlazorServerApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.DotNet.Scaffolding.Shared;
using System.Collections.ObjectModel;
using System.Security.Cryptography.Pkcs;

namespace BeitragRdrBlazorServerApp.Pages
{
    public partial class Index
    {
        [Inject]
        private IHttpDataAccess dataAccess { get; set; }

        [Inject]
        private AuthenticationStateProvider authProvider { get; set; }

        private UserReadDTO loggedInUser;

        private ObservableCollection<BeitragDTO>? beitrags;

        private List<CompanyReadDTO> companies;

        private string search = "";
        protected override async Task OnInitializedAsync()
        {
            loggedInUser = await authProvider.GetUserFromAuth(dataAccess);

            if(loggedInUser.companies.Count > 0)
            {
                companies = loggedInUser.companies;

                beitrags = new ObservableCollection<BeitragDTO>(companies.FirstOrDefault().beitrags.OrderByDescending(x => x.PostDate).ToList());
            }


            var authState = await authProvider.GetAuthenticationStateAsync();
            string objectId = authState.User.Claims.FirstOrDefault(c => c.Type.Contains("objectidentifier"))?.Value;

            if (string.IsNullOrWhiteSpace(objectId) == false)
            {
                
                loggedInUser = await dataAccess.GetUserByObjectId(objectId) ?? new();

                if(loggedInUser.Id == 0)
                {
                    UserCreateDTO userCreateDTO = new UserCreateDTO()
                    {
                        FirstName = authState.User.Claims.FirstOrDefault(c => c.Type.Contains("givenname"))?.Value,
                        LastName = authState.User.Claims.FirstOrDefault(c => c.Type.Contains("surname"))?.Value,
                        DisplayName = authState.User.Claims.FirstOrDefault(c => c.Type.Equals("name"))?.Value,
                        EmailAddress = authState.User.Claims.FirstOrDefault(c => c.Type.Contains("email"))?.Value,
                        ObjectIdentifier = objectId
                    };

                    dataAccess.CreateUser(userCreateDTO);
                }              
            }
        }


        private async Task DescOrder()
        {
            beitrags = new ObservableCollection<BeitragDTO>(beitrags.OrderByDescending(x => x.PostDate).ToList());
        }

        private async Task AscOrder()
        {
            beitrags = new ObservableCollection<BeitragDTO>(beitrags.OrderBy(x => x.PostDate).ToList());
        }

        private async Task FilterBeigtrags(string filter)
        {
            var output = companies.FirstOrDefault().beitrags;

            List<BeitragDTO> allbeitrags = output.ToList().Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();

            if (filter == "entwurf")
            {
                beitrags = new ObservableCollection<BeitragDTO>(allbeitrags.Where(x => x.BeitragStatus == BeitragStatus.Entwurf).ToList());
            }

            if(filter == "freigabe")
            {
                beitrags = new ObservableCollection<BeitragDTO>(allbeitrags.Where(x => x.BeitragStatus == BeitragStatus.Freigabe).ToList());
            }

            if(filter == "geplant")
            {
                beitrags = new ObservableCollection<BeitragDTO>(allbeitrags.Where(x => x.BeitragStatus == BeitragStatus.Geplant).ToList());
            }

            if (filter == "veröffentlicht")
            {
                beitrags = new ObservableCollection<BeitragDTO>(allbeitrags.Where(x => x.BeitragStatus == BeitragStatus.Veröffentlicht).ToList());
            }

            if ( filter == "all")
            {
                beitrags = new ObservableCollection<BeitragDTO>(allbeitrags.ToList());
            }
        }

        private async Task OnSearchInput(string searchtext)
        {
            var allbeitrags = await dataAccess.Beitrags();

            if (String.IsNullOrEmpty(searchtext))
            {
                beitrags = new ObservableCollection<BeitragDTO>(allbeitrags.ToList());
            }

            search = searchtext;

            List<BeitragDTO> result = beitrags.ToList().Where(x => x.Name.ToLower().Contains(searchtext.ToLower())).ToList();

            beitrags = new ObservableCollection<BeitragDTO>(result);
        }

        private void OpenDetails(BeitragDTO beitrag)
        {
            navManager.NavigateTo($"/Details/{beitrag.Id}");
        }

        private void OpenCreateBeitrag()
        {
            navManager.NavigateTo("/Create/");
        }
        
    }
}
