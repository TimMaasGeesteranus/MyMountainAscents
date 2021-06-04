using Microsoft.AspNetCore.Components;
using MyMountainAscents.Data.Entities;
using MyMountainAscents.UI.Components.Modals;
using MyMountainAscents.UI.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMountainAscents.UI.Pages
{
    public partial class MountainOverview
    {
        [Inject]
        IDataService DataService { get; set; }

        protected List<Mountain> Mountains;
        protected AddMountainModal AddMountainModal { get; set; }


        protected override async Task OnInitializedAsync()
        {
            try
            {
                Mountains = await DataService.GetAllMountains();
            }
            catch
            {
            }
        }
    }
}
