using BeitragRdr.DTOs;
using BeitragRdr.DTOs.CompanyDTOs;
using BeitragRdr.DTOs.SubModelsDTOs;
using BeitragRdr.Models.SubModels;
using BeitragRdrBlazorServerApp.Data;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;

namespace BeitragRdrBlazorServerApp.Pages
{
    public partial class Update
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        private IHttpDataAccess dataAccess { get; set; }

        private BeitragDTO beitragDTO;

        public TagsDTO tag { get; set; } = new TagsDTO();

        public ObservableCollection<TagsDTO> tagstoupload { get; set; } = new ObservableCollection<TagsDTO>();

        private List<CompanyReadDTO>? companies { get; set; }

        private BeitragFaceDTO beitragFace { get; set; } = new BeitragFaceDTO();
        private BeitragInstaDTO beitragInsta { get; set; } = new BeitragInstaDTO();

        private BeitragPintrDTO beitragPintr { get; set; } = new BeitragPintrDTO();

        private bool showAlert = false;
        public bool ShowAlert
        {
            get => showAlert;
            set
            {
                if (value != showAlert)
                {
                    showAlert = value;
                    StateHasChanged();
                }
            }
        }

        public void ToggleAlert() => ShowAlert = true;
        public void DissmissAlert() => ShowAlert = false;


        protected async override Task OnInitializedAsync()
        {
            companies = await dataAccess.Companies();

            beitragDTO = await dataAccess.BeitragById(Convert.ToInt32(Id));

            if (beitragDTO.beitragFace is not null)
            {
                beitragFace = beitragDTO.beitragFace;
            }

            if (beitragDTO.beitragInsta is not null)
            {
                beitragInsta = beitragDTO.beitragInsta;
            }

            if (beitragDTO.beitragPintr is not null)
            {
                beitragPintr = beitragDTO.beitragPintr;
            }

        }

        protected async Task OnValidSubmit()
        {
            if (String.IsNullOrEmpty(beitragFace.Name))
            {
                beitragDTO.beitragFace = null;
            }
            else
            {
                beitragDTO.beitragFace = beitragFace;
            }

            if (String.IsNullOrEmpty(beitragInsta.Name))
            {
                beitragDTO.beitragInsta = null;
            }
            else
            {
                beitragDTO.beitragInsta = beitragInsta;
            }

            if (String.IsNullOrEmpty(beitragPintr.Name))
            {
                beitragDTO.beitragPintr = null;
            }
            else
            {
                beitragDTO.beitragPintr = beitragPintr;
            }

            await dataAccess.UpdateBeitrag(beitragDTO.Id, beitragDTO);


            navManager.NavigateTo($"/Details/{beitragDTO.Id}");
        }

        private async Task AddToTagList()
        {
            if (!string.IsNullOrEmpty(tag.Tag))
            {
                await Task.Run(() => beitragDTO.tags.Add(new TagsDTO { Tag = tag.Tag }));

                ToggleAlert();
            }
        }

        private async Task RemoveTag(TagsDTO tag)
        {
            await Task.Run(() => beitragDTO.tags.Remove(tag));
        }

        private void Back()
        {
            navManager.NavigateTo($"/Details/{Id}");
        }
    }

}
