using BeitragRdr.DTOs;
using BeitragRdrBlazorServerApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.JsonPatch;
using System.Configuration;

namespace BeitragRdrBlazorServerApp.Pages
{
    public partial class Details
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        private IHttpDataAccess dataAccess { get; set; }

        private BeitragDTO? beitragDTO;

        protected async override Task OnInitializedAsync()
        {
            beitragDTO = await dataAccess.BeitragById(Convert.ToInt32(Id));
        }     

        private void Back()
        {
            navManager.NavigateTo("/");
        }

        private void Edit(BeitragDTO beitrag)
        {
            navManager.NavigateTo($"/Update/{beitrag.Id}");
        }

        private void Delete(BeitragDTO beitrag)
        {
            dataAccess.DeleteBeitrag(beitrag.Id);

            navManager.NavigateTo("/");
        }

        private void Frei()
        {
            var patchDoc = new JsonPatchDocument<BeitragDTO>();
            patchDoc.Replace(e => e.BeitragStatus.Value, BeitragStatus.Geplant);

            dataAccess.PartialUpdateBeitrag(beitragDTO.Id, patchDoc);

            navManager.NavigateTo("/");
        }
    }
}
