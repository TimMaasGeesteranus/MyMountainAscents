using Microsoft.AspNetCore.Components;
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

        protected Ascent newAscent = new();

        protected (bool ShowBackdrop, string Class) Modal = (false, "");

        public void Open()
        {
            Modal = (true, "show d-block");
            StateHasChanged();
        }

        public void Close()
        {
            Modal = (false, "");
            StateHasChanged();
        }

        public void AddAscent()
        {
            //doe iets
        }

    }
}
