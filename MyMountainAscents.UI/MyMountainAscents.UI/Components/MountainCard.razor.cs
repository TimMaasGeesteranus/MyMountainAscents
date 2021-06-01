using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyMountainAscents.Data.Entities;

namespace MyMountainAscents.UI.Components
{
    public partial class MountainCard
    {
        [Parameter]
        public Mountain Mountain { get; set; }

        public string imgSrc;

        protected override void OnInitialized()
        {
            if (Mountain.Image != null)
            {
                var base64 = Convert.ToBase64String(Mountain.Image);
                imgSrc = String.Format("data:image/gif;base64,{0}", base64);
            }
        }

        public void GoToDetails()
        {

        }

    }
}
