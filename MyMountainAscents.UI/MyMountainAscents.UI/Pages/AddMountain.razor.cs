using Microsoft.AspNetCore.Components;
using MyMountainAscents.Data.Entities;
using MyMountainAscents.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMountainAscents.UI.Pages
{
    public partial class AddMountain
    {
        protected Mountain mountain = new();

        [Inject]
        IDataService DataService { get; set; }

        public async Task Submit()
        {
            try
            {
                await DataService.AddMountain(mountain);
            }
            catch (Exception e)
            {
            }
        }
    }
}

