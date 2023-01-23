using BeitragRdr.DTOs;
using BeitragRdrBlazorServerApp.Data;
using Microsoft.AspNetCore.Components;

namespace BeitragRdrBlazorServerApp.Pages
{
    public partial class Create
    {
        [Inject]
        private IHttpDataAccess dataAccess { get; set; }

        private CreateBeitragDTO createBeitragDTO { get; set; } = new CreateBeitragDTO();

        protected async Task OnValidSubmit()
        {
            var x = dataAccess.CreateBeitrag(createBeitragDTO);

            navManager.NavigateTo("/");
        }

    }
}
