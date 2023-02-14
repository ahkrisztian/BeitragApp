using BeitragRdr.DTOs;
using BeitragRdr.DTOs.CompanyDTOs;
using BeitragRdr.DTOs.ImageModelsDTOs;
using BeitragRdr.DTOs.SubModelsDTOs;
using BeitragRdr.Models.UserModel;
using BeitragRdrBlazorServerApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.ObjectModel;

namespace BeitragRdrBlazorServerApp.Pages
{
    public partial class Create
    {
        [Inject]
        private IDataAccess dataAccess { get; set; }

        [Inject]
        private AuthenticationStateProvider authProvider { get; set; }

        [Parameter]
        public UserReadDTO loggedInUser { get; set; }

        [Parameter]
        public CreateBeitragDTO createBeitragDTO { get; set; }

        private List<CompanyReadDTO> companies { get; set; }
        [Parameter]
        public TagsDTO tag { get; set; } = new TagsDTO();
        public ObservableCollection<TagsDTO> tagstoupload { get; set; } = new ObservableCollection<TagsDTO>();

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

        protected override async Task OnInitializedAsync()
        {
            
            loggedInUser = await authProvider.GetUserFromAuth(dataAccess);

            companies = await dataAccess.Companies();
        }

        protected override Task OnParametersSetAsync()
        {
            createBeitragDTO = new CreateBeitragDTO()
            {
                beitragFace = new BeitragFaceDTO(),
                beitragInsta = new BeitragInstaDTO(),
                beitragPintr = new BeitragPintrDTO(),
                tags = new List<TagsDTO>()
            };

            return base.OnParametersSetAsync();
        }

        protected async Task OnValidSubmit()
        {
            if(tagstoupload.Count > 0)
            {
                createBeitragDTO.tags.AddRange(tagstoupload);
            }

            if(createBeitragDTO.beitragFace.Name is null)
            {
                createBeitragDTO.beitragFace = null;
            }

            if(createBeitragDTO.beitragInsta.Name is null)
            {
                createBeitragDTO.beitragInsta = null;
            }

            if(createBeitragDTO.beitragPintr?.Name is null)
            {
                createBeitragDTO.beitragPintr = null;
            }

            await dataAccess.CreateBeitrag(createBeitragDTO);

            createBeitragDTO = new CreateBeitragDTO()
            {
                beitragFace = new BeitragFaceDTO(),
                beitragInsta = new BeitragInstaDTO(),
                beitragPintr = new BeitragPintrDTO(),
                tags = new List<TagsDTO>()
            };

            navManager.NavigateTo("/");
           
        }

        public void ToggleAlert() => ShowAlert = true;
        public void DissmissAlert() => ShowAlert = false;

        private void AddToTagList()
        {
            if (!string.IsNullOrEmpty(tag?.Tag))
            {
                tagstoupload.Add(new TagsDTO { Tag = tag.Tag });

                ToggleAlert();
            }
        }

        private void RemoveTag(TagsDTO tag)
        {
            tagstoupload.Remove(tag);
        }

        private void Back()
        {
            navManager.NavigateTo("/");
        }

    }
}
