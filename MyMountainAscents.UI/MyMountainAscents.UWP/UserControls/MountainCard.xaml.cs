using MyMountainAscents.UWP.ViewModels;
using System;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace MyMountainAscents.UWP.UserControls
{
    public sealed partial class MountainCard : UserControl
    {
        public MountainCollectionViewModel Mountains { get; set; }

        public MountainCard()
        {
            this.InitializeComponent();
            Mountains = new MountainCollectionViewModel();
        }

        //public static ImageSource DoeIets(byte[] imageBytes)
        //{
        //    BitmapImage image = new BitmapImage();
        //    InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream();
        //    ms.AsStreamForWrite().Write(imageBytes, 0, imageBytes.Length);
        //    ms.Seek(0);

        //    image.SetSource(ms);
        //    ImageSource src = image;

        //    return src;
        //}

        public static ImageSource DoeIets(byte[] imageBytes)
        {
            ImageSource result = new BitmapImage(new Uri("ms-appx:///Assets/Mountains/Matterhorn.png"));
            return result;
        }
    }
}
