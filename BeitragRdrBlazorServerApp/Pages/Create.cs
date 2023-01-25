using BeitragRdr.DTOs;
using BeitragRdr.DTOs.CompanyDTOs;
using BeitragRdr.DTOs.ImageModelsDTOs;
using BeitragRdr.DTOs.SubModelsDTOs;
using BeitragRdrBlazorServerApp.Data;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;

namespace BeitragRdrBlazorServerApp.Pages
{
    public partial class Create
    {
        [Inject]
        private IHttpDataAccess dataAccess { get; set; }     
        private CreateBeitragDTO createBeitragDTO { get; set; } = new CreateBeitragDTO() 
        {
            beitragFace = new BeitragFaceDTO(),
            beitragInsta= new BeitragInstaDTO(),
            beitragPintr=new BeitragPintrDTO(),
            tags = new List<TagsDTO>()
        };

        private BeitragFaceDTO beitragFace { get; set; } = new BeitragFaceDTO();
        private BeitragInstaDTO beitragInsta { get; set; } = new BeitragInstaDTO();

        private BeitragPintrDTO beitragPintr { get; set; } = new BeitragPintrDTO();



        private List<CompanyReadDTO?> companies { get; set; } = new List<CompanyReadDTO?>();
        public TagsDTO? tag { get; set; } = new TagsDTO();
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
            companies = await dataAccess.Companies();

            base.OnInitializedAsync();
        }

        protected async Task OnValidSubmit()
        {
            if(tagstoupload.Count > 0)
            {
                createBeitragDTO.tags.AddRange(tagstoupload);
            }

            createBeitragDTO.beitragFace = beitragFace;
            createBeitragDTO.beitragInsta= beitragInsta;
            createBeitragDTO.beitragPintr = beitragPintr;

            var x = dataAccess.CreateBeitrag(createBeitragDTO);

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

        private async Task AddToTagList()
        {
            if (tag != null)
            {
                tagstoupload.Add(new TagsDTO { Tag = tag.Tag });
            }
        }

        private async Task RemoveTag(TagsDTO tag)
        {
            tagstoupload.Remove(tag);
        }

    }
}
