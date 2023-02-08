using BeitragRdr.DTOs;
using BeitragRdrBlazorServerApp.Data;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;

namespace BeitragRdrBlazorServerApp.Pages
{
    public partial class Index
    {
        [Inject]
        private IHttpDataAccess dataAccess { get; set; }

        private ObservableCollection<BeitragDTO>? beitrags;

        private string search = "";
        protected override async Task OnInitializedAsync()
        {
            var allbeitrags = await dataAccess.Beitrags();

            beitrags = new ObservableCollection<BeitragDTO>(allbeitrags.OrderByDescending(x => x.PostDate).ToList());


            base.OnInitializedAsync();
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
            var output = await dataAccess.Beitrags();

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
