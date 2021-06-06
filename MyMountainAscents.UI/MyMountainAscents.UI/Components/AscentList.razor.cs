using Microsoft.AspNetCore.Components;
using MyMountainAscents.Data.Entities;
using MyMountainAscents.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMountainAscents.UI.Components
{
    public partial class AscentList
    {
        [Parameter]
        public List<Ascent> Ascents { get; set; }

        [Parameter]
        public Guid MountainGuid { get; set; }

        [Inject]
        IDataService DataService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        public async void Delete(Ascent ascent)
        {
            try
            {
                await DataService.DeleteAscent(ascent.Id);
                NavigationManager.NavigateTo($"/mountainDetail/{MountainGuid}", true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
    }
    }


}
