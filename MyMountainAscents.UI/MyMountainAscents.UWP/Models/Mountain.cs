using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

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

        public Mountain(string name, int height, string country)
            => (Name, Height, Country) = (name, height, country);

        public Mountain(string name, int height, string country, byte[] image)
            => (Name, Height, Country, Image) = (name, height, country, image);
    }
}
