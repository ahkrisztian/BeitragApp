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


        protected override async Task OnInitializedAsync()
        {
            var allbeitrags = await dataAccess.Beitrags();

            beitrags = new ObservableCollection<BeitragDTO>(allbeitrags.OrderByDescending(x => x.PostDate).ToList());

            base.OnInitializedAsync();
        }

        private async Task DescOrder()
        {
            var allbeitrags = await dataAccess.Beitrags();

            beitrags = new ObservableCollection<BeitragDTO>(allbeitrags.OrderByDescending(x => x.PostDate).ToList());
        }

        private async Task AscOrder()
        {
            var allbeitrags = await dataAccess.Beitrags();

            beitrags = new ObservableCollection<BeitragDTO>(allbeitrags.OrderBy(x => x.PostDate).ToList());
        }
    }
}
