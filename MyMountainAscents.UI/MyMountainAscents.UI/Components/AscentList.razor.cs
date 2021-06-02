using Microsoft.AspNetCore.Components;
using MyMountainAscents.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMountainAscents.UI.Components
{
    public partial class AscentList
    {
        [Parameter]
        public List<Ascent> Ascents { get; set; }
    }
}
