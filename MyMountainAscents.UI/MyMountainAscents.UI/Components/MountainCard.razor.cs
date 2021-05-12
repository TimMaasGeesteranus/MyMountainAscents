using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMountainAscents.UI.Components
{
    public partial class MountainCard
    {
        [Parameter]
        public string Title { get; set; }

    }
}
