using Microsoft.AspNetCore.Components;
using MyMountainAscents.Data.Entities;
using MyMountainAscents.Data.Services;
using MyMountainAscents.UI.Components.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMountainAscents.UI.Pages
{
    public partial class MountainDetail
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        IDataService DataService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        protected AddAscentModal AddAscentModal { get; set; }

        protected Mountain Mountain;
        protected string imgSrc;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Mountain = await DataService.GetMountainByGuid(Guid.Parse(Id));
                var base64 = Convert.ToBase64String(Mountain.Image);
                imgSrc = String.Format("data:image/gif;base64,{0}", base64);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        protected int GetAscents()
            => Mountain.Ascents?.Count ?? 0;

        public async Task Delete()
        {
            try
            {
                await DataService.DeleteMountain(Mountain.Id);
                NavigationManager.NavigateTo("/mountainOverview");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
