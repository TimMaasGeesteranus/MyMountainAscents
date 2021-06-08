using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMountainAscents.UWP.Models
{
    public class Mountain
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public string Country { get; set; }
        public byte[] Image { get; set; }
        public List<Ascent> Ascents { get; set; }
    }
}
