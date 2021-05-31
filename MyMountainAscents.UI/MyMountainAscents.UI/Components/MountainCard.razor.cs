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

    }
}
