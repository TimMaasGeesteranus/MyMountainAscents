using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MyMountainAscents.Data.Entities;
using MyMountainAscents.UI.Services;
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task UploadFile(InputFileChangeEventArgs e)
        {
            MemoryStream ms = new();
            await e.File.OpenReadStream().CopyToAsync(ms);
            var bytes = ms.ToArray();
            mountain.Image = bytes;
        }
    }
}

