﻿using Microsoft.AspNetCore.Components;
using MyMountainAscents.Data.Entities;
using MyMountainAscents.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMountainAscents.UI.Components.Modals
{
    public partial class AddAscentModal
    {
        [Inject]
        IDataService DataService { get; set; }

        [Parameter]
        public Mountain Mountain { get; set; }

        protected Ascent newAscent = new();

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

        public async void AddAscent()
        {
            newAscent.Mountain = Mountain;
            try
            {
                await DataService.AddAscent(newAscent, Mountain.Id);
                Close();
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }

    }
}
