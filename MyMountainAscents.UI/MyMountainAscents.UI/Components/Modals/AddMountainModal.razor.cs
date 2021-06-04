using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MyMountainAscents.Data.Entities;
using MyMountainAscents.UI.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyMountainAscents.UI.Components.Modals
{
    public partial class AddMountainModal
    {
        [Inject]
        IDataService DataService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        protected Mountain NewMountain = new();

        protected (bool ShowBackdrop, string Class) Modal = (false, "");

        public void Open()
        {
            Modal = (true, "show d-block");
            StateHasChanged();
        }

        public void Close()
        {
            Console.WriteLine("0");
            Modal = (false, "");
            StateHasChanged();
        }

        public async void AddMountain()
        {
            try
            {
                await DataService.AddMountain(NewMountain);
                NavigationManager.NavigateTo("/mountainOverview", true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task UploadFile(InputFileChangeEventArgs e)
        {
            MemoryStream ms = new();
            await e.File.OpenReadStream().CopyToAsync(ms);
            var bytes = ms.ToArray();
            NewMountain.Image = bytes;
        }
    }
}
