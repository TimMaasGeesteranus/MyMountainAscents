using Microsoft.AspNetCore.Components;
using MyMountainAscents.API.Entities;
using MyMountainAscents.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMountainAscents.UI.Pages
{
    public partial class MountainOverview
    {
        [Inject]
        IDataService DataService { get; set; }

        public string Error = "alles prima";

        public async Task AddMountain()
        {
            Error = "Trying...";
            Mountain mountain = new();
            mountain.Name = "Matterhorn";
            mountain.Country = "Zwitserland";
            mountain.Height = 4003;
            try
            {
                await DataService.AddMountain(mountain);
                Error = "Completed!";
            }
            catch (Exception e)
            {
                Error = e.ToString();
            }
        }
    }
}
