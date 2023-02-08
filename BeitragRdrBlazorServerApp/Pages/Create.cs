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

        private List<CompanyReadDTO>? companies { get; set; }
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
            companies = await dataAccess.Companies();
        }

        protected async Task OnValidSubmit()
        {
            if(tagstoupload.Count > 0)
            {
                createBeitragDTO.tags.AddRange(tagstoupload);
            }

            if(beitragFace.Name is not null)
            {
                createBeitragDTO.beitragFace = beitragFace;
            }
            else
            {
                createBeitragDTO.beitragFace = null;
            }

            if (beitragInsta.Name is not null)
            {
                createBeitragDTO.beitragInsta = beitragInsta;
            }
            else
            {
                createBeitragDTO.beitragInsta = null;
            }

            if (beitragPintr.Name is not null)
            {
                createBeitragDTO.beitragPintr = beitragPintr;
            }
            else
            {
                createBeitragDTO.beitragPintr = null;
            }


            await dataAccess.CreateBeitrag(createBeitragDTO);


            navManager.NavigateTo("/");
        }

        public void ToggleAlert() => ShowAlert = true;
        public void DissmissAlert() => ShowAlert = false;

        private async Task AddToTagList()
        {
            if (!string.IsNullOrEmpty(tag.Tag))
            {
                await Task.Run(() => tagstoupload.Add(new TagsDTO { Tag = tag.Tag }));

                ToggleAlert();
            }
        }

        private async Task RemoveTag(TagsDTO tag)
        {
            await Task.Run(() => tagstoupload.Remove(tag));
        }

    }
}
