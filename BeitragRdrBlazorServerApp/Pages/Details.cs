using BeitragRdr.DTOs;
using BeitragRdrBlazorServerApp.Data;
using Microsoft.AspNetCore.Components;
using System.Configuration;

namespace BeitragRdrBlazorServerApp.Pages
{
    public partial class Details
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        private IHttpDataAccess dataAccess { get; set; }

        private BeitragDTO beitragDTO;

        protected async override Task OnInitializedAsync()
        {
            beitragDTO = await dataAccess.BeitragById(Convert.ToInt32(Id));
        }     
    }
}
