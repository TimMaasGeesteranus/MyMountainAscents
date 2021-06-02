using Microsoft.AspNetCore.Components;
using MyMountainAscents.Data.Entities;
using MyMountainAscents.UI.Services;
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

        protected Mountain Mountain;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Mountain = await DataService.GetMountainByGuid(Guid.Parse(Id));
            }
            catch
            {
            }
        }

    }
}
